using UnityEngine;

public class AIWalking : AI
{
  public float WalkingTimeMin = 1.0f;
  public float WalkingTimeMax = 5.0f;
  public float IdleTimeMin = 1.0f;
  public float IdleTimeMax = 5.0f;

  protected bool Direction;
  protected float Speed = 1.0f;
  protected float WalkingTime;
  protected float IdleTime;

  private Camera _camera;
  private Transform _cameraTransform;
  private Transform _transform;

  protected override void OnStart()
  {
    _transform = transform;
    _camera = Camera.main;
    _cameraTransform = _camera.transform;
    Rigidbody2D.isKinematic = false;
    Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    Rigidbody2D.velocity = Vector2.zero;
    base.OnStart();
    StartWalking();
  }

  protected override void OnUpdate()
  {
    if (Mathf.Abs(_cameraTransform.position.x - _transform.position.x) >= 15f
        || Mathf.Abs(_cameraTransform.position.y - _transform.position.y) >= 2000f)
    {
      Rigidbody2D.isKinematic = true;
      Rigidbody2D.simulated = false;
      Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
      return;
    }
    Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    Rigidbody2D.simulated = true;

    Rigidbody2D.isKinematic = false;

    if (WalkingTime > 0.0f)
    {
      Vector3 pos = transform.position;
      pos.x = pos.x + Speed * Time.deltaTime * (Direction ? 1.0f : -1.0f);
      transform.position = pos;
      WalkingTime -= Time.deltaTime;

      if (WalkingTime <= 0.0f)
        StopWalking();
    }
    else if (IdleTime > 0.0f)
    {
      IdleTime -= Time.deltaTime;

      if (IdleTime <= 0.0f)
        StartWalking();
    }

    base.OnUpdate();
  }

  protected override void OnCollisionEnterEvent(Collision2D collision)
  {
    base.OnCollisionEnterEvent(collision);

    if (collision.collider.name == "EntityItem(Clone)")
    {
      if (WalkingTime > 0)
        StopWalking(10.0f);
    }
    else
    {
      bool collisionFloor = true;

      foreach (ContactPoint2D point in collision.contacts)
      {
        if (point.point.y > collision.otherCollider.bounds.center.y)
          collisionFloor = false;
      }

      if (!collisionFloor)
        SetDirection(!Direction);
    }
  }

  protected void StartWalking()
  {
    IdleTime = 0.0f;
    WalkingTime = Random.Range(WalkingTimeMin, WalkingTimeMax);
    GetComponent<Animator>().SetBool("walking", true);
    SetDirection(Random.Range(0, 2) == 0);
  }

  protected void StopWalking()
  {
    StopWalking(Random.Range(IdleTimeMin, IdleTimeMax));
  }

  protected void StopWalking(float time)
  {
    WalkingTime = 0;
    GetComponent<Animator>().SetBool("walking", false);
    IdleTime = time;
  }

  protected void SetDirection(bool d)
  {
    Direction = d;
    GetComponent<SpriteRenderer>().flipX = !Direction;
  }
}
