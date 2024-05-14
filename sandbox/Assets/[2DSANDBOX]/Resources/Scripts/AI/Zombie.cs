using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zombie : AIWalking
{
    public float lightDistance = 5.0f;
    
    bool playerSeen;
    bool chicken;
    float playerSeenBoost = 2.0f;

    protected override void OnStart()
    {
        base.OnStart();
        StartCoroutine(WatchPlayer());
        StartCoroutine(WatchLight());
    }

    protected override void OnUpdate()
    {
        if (playerSeen && !chicken)
        {
            Vector3 pos = transform.position;
            SetDirection(World.instance.playerObj.transform.position.x > pos.x);
            pos.x = pos.x + Speed * playerSeenBoost * Time.deltaTime * (Direction ? 1.0f : -1.0f);
            transform.position = pos;
            WalkingTime = 0;
        }

        base.OnUpdate();
    }

    protected override void OnCollisionEnterEvent(Collision2D collision)
    {
        base.OnCollisionEnterEvent(collision);

        if (!chicken && collision.collider.gameObject == World.instance.playerObj)
        {
            GameObject.FindObjectOfType<Heart>().Hit();
            //SceneManager.LoadScene("World");
        }
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
                StartWalking();

            playerSeen = newPlayerSeen;
        }
    }

    IEnumerator WatchLight()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            bool setChicken = false;

            foreach (Light light in FindObjectsOfType<Light>())
            {
                if (light.name == "Torch(Clone)" && light.enabled)
                {
                    float distance = Vector2.Distance(transform.position, light.transform.position);

                    if (distance <= lightDistance)
                    {
                        if (!chicken)
                            GetComponent<Animator>().SetBool("chicken", true);

                        chicken = true;
                        StartWalking();
                        setChicken = true;
                        break;
                    }
                }
            }

            if (!setChicken && chicken)
            {
                GetComponent<Animator>().SetBool("chicken", false);
                chicken = false;
            }
        }
    }
}