using System.Collections;
using UnityEngine;


public enum BlockState
{
      Idle
    , Move
}

public class AI : MonoBehaviour
{
  [HideInInspector]
  public TileAsset tile;

  public bool IsBlock;



  protected Rigidbody2D Rigidbody2D;
  private Vector3 _currentPositionInChunk;
  private BlockState _currentState = BlockState.Idle;
  private BlockState _previoustState = BlockState.Idle;

  protected bool IsReplace;

  private void Start()
  {
    Rigidbody2D = GetComponent<Rigidbody2D>();
    _currentPositionInChunk = transform.position;
    OnStart();
    if(IsBlock)
      StartCoroutine(CheckVelocity());
  }

  private void Update()
  {
    OnUpdate();
    _currentState = Rigidbody2D.velocity != Vector2.zero ? BlockState.Move : BlockState.Idle;
    if (!IsBlock) return;
  }

  private void FixedUpdate()
  {

    //Debug.Log(string.Format("{0} - velocity {1}", name, Rigidbody2D.velocity));
  }

  private IEnumerator CheckVelocity()
  {
    _previoustState = _currentState;
    yield return new WaitForSeconds(0.5f);
    if (_currentState != _previoustState)
    {
      if (_currentState == BlockState.Idle)
      {
        Tile currentTile = TileStore.createTile(tile.id);
        World.instance.UpdateBlockForce(currentTile, transform.position);
        IsReplace = true;
        Destroy(gameObject);
      }
      if (_currentState == BlockState.Move)
      {
        World.instance.RemoveBlock(_currentPositionInChunk);
      }
    }

    StartCoroutine(CheckVelocity());
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    OnCollisionEnterEvent(collision);
  }

  protected virtual void OnStart()
  {
  }

  protected virtual void OnUpdate()
  {
  }

  protected virtual void OnCollisionEnterEvent(Collision2D collision)
  {
  }
}