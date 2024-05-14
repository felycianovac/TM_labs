using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;



public class Pumpkin : AIWalking
{
    public int maxHits = 3;  // Maximum hits before the pumpkin is destroyed
    private int hitCount = 0;  // Current number of times the pumpkin has been hit

    bool playerSeen;
    float playerSeenBoost = 2.0f;
    public Inventory playerInventory;
    

    protected override void OnStart()
    {
        base.OnStart();
        StartCoroutine(WatchPlayer());
        
    }

    protected override void OnUpdate()
    {
        if (playerSeen)
        {
            Vector3 pos = transform.position;
            SetDirection(World.instance.playerObj.transform.position.x > pos.x);
            pos.x = pos.x + Speed * playerSeenBoost * Time.deltaTime * (Direction ? 1.0f : -1.0f);
            transform.position = pos;
            WalkingTime = 0;
        }
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Perform a raycast to see what the mouse is clicking on
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            // Check if the pumpkin was clicked
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // Call a method to handle the hit
                HandleHit();
            }
        }
        base.OnUpdate();

    }

    IEnumerator WatchPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            RaycastHit2D hit;

            hit = Physics2D.Raycast(transform.position, World.instance.playerObj.transform.position - transform.position);

            bool newPlayerSeen = hit.collider.gameObject == World.instance.playerObj;

            if (playerSeen && !newPlayerSeen)
                UnityEngine.Debug.Log("PLAYER SEEN!");
                StartWalking();

            playerSeen = newPlayerSeen;
        }
    }

       protected override void OnCollisionEnterEvent(Collision2D collision)
    {
        base.OnCollisionEnterEvent(collision);

        if (collision.collider.gameObject == World.instance.playerObj)
        {
            //SceneManager.LoadScene("World");

            GameObject.FindObjectOfType<Heart>().Hit();

        }
    }

    // private void Update()
    // {
    //     // Check if the left mouse button was clicked
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         // Perform a raycast to see what the mouse is clicking on
    //         RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
    //         // Check if the pumpkin was clicked
    //         if (hit.collider != null && hit.collider.gameObject == gameObject)
    //         {
    //             // Call a method to handle the hit
    //             HandleHit();
    //         }
    //     }
    // }

    private void HandleHit()
    {
        EquipmentSlot toolSlot = PauseScreen._instance.equipmentSlots[73];
        // Check if the player is holding the correct tool (axe with toolID 30)
        if (toolSlot.id == 30)  // Make sure PlayerInventory has a method GetCurrentToolID
        {
            hitCount++;  // Increment the hit counter
            if (hitCount >= maxHits)
            {
                Destroy(gameObject);  // Destroy the pumpkin when hit count reaches maxHits
            }
        }
    }
    



}
    




