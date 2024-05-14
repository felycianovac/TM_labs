using UnityEngine;

public class GravityBox : AI
{
  Collider2D col;
  private bool _isDestroyed;

  protected override void OnStart()
  {
    col = GetComponent<Collider2D>();
  }

  protected override void OnUpdate()
  {
    if (Input.GetMouseButtonDown(0) && !_isDestroyed)
    {
      if (IsReplace)
      {
        Destroy(gameObject);
        return;
      }
      Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

      if (col.OverlapPoint(mousePosition))
      {
        _isDestroyed = true;
        Destroy(gameObject);

        EntityItem item = (EntityItem)EntityStore.createEntity(0);

        item.itemID = tile.droppedItem.id;

        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        item.transform.position = new Vector3(pos.x - 0.5f, pos.y - 0.5f, 1.0f);
      }
    }
  }

  protected override void OnCollisionEnterEvent(Collision2D collision)
  {
  }
}
