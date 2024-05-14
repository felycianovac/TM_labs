using System.Collections;
using UnityEngine;

public class Bird : AI
{
  public float lightDistance = 5.0f;
  public float MaxRange = 20f;
  public float MinRange = 5f;
  float speed = 1.0f;
  Vector3 lightTriggerPosition;
  Transform lightTransform;
  Light lightTarget;
  float lightStartIntensity;
  State state;
  float waitTime;
  float waitMax;

  private Vector3 targetPosition;

  enum State
  {
    OnTrack,
    GoToLight,
    Return,
    Die
  }

  Vector3 direction = Vector3.right;

  private SpriteRenderer _spriteRenderer;
  private Animator _animator;

  protected override void OnStart()
  {
    _spriteRenderer = GetComponent<SpriteRenderer>();
    _animator = GetComponent<Animator>();

    base.OnStart();
    StartFlying();
    StartCoroutine(WatchLight());
    ResetTrack();
  }

  protected override void OnUpdate()
  {
    if (state != State.Die)
    {
      var step = speed * Time.deltaTime;

      if (state == State.OnTrack || state == State.Return)
      {
        transform.Translate(direction * Time.deltaTime);
      }
      else
      {
        targetPosition.z = 1;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
      }
    }

    if (!lightTransform && state != State.OnTrack)
    {
      state = State.OnTrack;
      direction = Vector3.right;
      //state = state == State.Return ? State.Return : State.OnTrack;

      //waitTime = waitMax;
    }

    if (state == State.GoToLight && lightTransform && CheckDistance(lightTransform.position))
    {
      targetPosition = lightTriggerPosition;
      targetPosition.z = 1f;
      //direction = Vector3.right;
      Vector3 dir = lightTriggerPosition - transform.position;
      //Vector3 dir = lightTransform.position - transform.position;
      direction = new Vector3(dir.x, dir.y, 0);
      direction.Normalize();
      SetFlip();
      state = State.Return;

      if (lightTarget)
      {
        if (lightTarget.intensity == lightStartIntensity)
          lightTarget.intensity *= 0.5f;
        else
        {
          lightTarget.enabled = false;
          lightTarget.GetComponent<Animator>().SetBool("off", true);

          Tile tile = TileStore.createTile(41); //TorchOff
          World.instance.SetBlockForce(tile, lightTarget.transform.position);
        }
      }
    }

    if (state == State.Return && CheckDistance(lightTriggerPosition))
      ResetTrack();

    waitTime += Time.deltaTime;

    base.OnUpdate();
  }

  private void ResetTrack()
  {
    direction = Vector3.right;
    var pos = lightTriggerPosition;
    //pos.x += 10;
    //pos.y += 10;
    pos.z = 1f;
    targetPosition = pos;
    SetFlip();
    state = State.OnTrack;
    waitTime = 0;
    waitMax = Random.Range(5.0f, 10.0f);
  }

  private bool CheckDistance(Vector3 position)
  {
    return Vector2.Distance(transform.position, position) <= 0.1f;
  }

  protected override void OnCollisionEnterEvent(Collision2D collision)
  {
    base.OnCollisionEnterEvent(collision);

    if (state == State.GoToLight)
      state = State.Return;

    if (state != State.Return)
      InvertDirection();

    if (collision.collider.GetComponent<GravityBox>())
    {
      _animator.SetBool("die", true);
      state = State.Die;
      Destroy(gameObject, 0.33f);
    }
  }

  protected void StartFlying()
  {
    _animator.SetBool("walking", true);
  }

  protected void InvertDirection()
  {
    direction = new Vector3(-direction.x, -direction.y, 0.0f);
    SetFlip();
  }

  private void SetFlip()
  {
    _spriteRenderer.flipX = direction.x < 0.0f;
  }

  private void SetFlip(bool isLeft)
  {
    _spriteRenderer.flipX = isLeft;
  }

  IEnumerator WatchLight()
  {
    while (true)
    {
      yield return new WaitForSeconds(0.5f);

      foreach (Light light in FindObjectsOfType<Light>())
      {
        if (light.name == "Torch(Clone)")
        {
          float distance = Vector2.Distance(transform.position, light.transform.position);

          if (distance <= lightDistance)
          {
            RaycastHit2D hit;
            Vector3 dir = light.transform.position - transform.position;

            hit = Physics2D.Raycast(transform.position, dir);

            if (Vector2.Distance(hit.point, transform.position) > distance)
            {
              if (state == State.OnTrack && waitTime > waitMax && light.enabled)
              {
                dir.Normalize();
                direction = new Vector3(dir.x, dir.y, 1.0f);
                SetFlip();
                lightTriggerPosition = transform.position;
                lightTransform = light.transform;
                lightTarget = light;
                targetPosition = light.transform.position;

                if (lightStartIntensity == 0)
                  lightStartIntensity = light.intensity;

                state = State.GoToLight;
              }
              break;
            }
          }
        }
      }
    }
  }
}