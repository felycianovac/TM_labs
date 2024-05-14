using System.Linq;
using UnityEngine;

public class Balloon : AI
{

  public float Strength = 3.5f;
  public float MaxVelocity = 50f;

  public CircleCollider2D CircleCollider2D;


  protected override void OnStart()
  {
    //var filter = new ContactFilter2D();

    //var colliders = new Collider2D[10];

    //var result = CircleCollider2D.OverlapCollider(filter, colliders);
    Rigidbody2D = GetComponent<Rigidbody2D>();
    base.OnStart();

  }

  void FixedUpdate()
  {
    if (Rigidbody2D.velocity.y >= MaxVelocity) return;
    Rigidbody2D.AddForce(Vector3.up * Strength);
    Debug.Log(Rigidbody2D.velocity);
  }

  void OnCollisionEnter2D(Collision2D coll)
  {

    var collider = coll.collider;
    var RectWidth = CircleCollider2D.bounds.size.x;
    var RectHeight = CircleCollider2D.bounds.size.y;
    var circleRad = collider.bounds.size.x;


    Vector3 contactPoint = coll.contacts.FirstOrDefault(x => x.collider == collider).point;
    Vector3 center = collider.bounds.center;


    if (contactPoint.y > center.y)
    {
      if (contactPoint.x <= center.x + RectWidth / 2 && contactPoint.x >= center.x - RectWidth / 2)
      {
        coll.transform.SetParent(transform);

        Debug.LogError("FromBottom");
      }
    }
  }
}
