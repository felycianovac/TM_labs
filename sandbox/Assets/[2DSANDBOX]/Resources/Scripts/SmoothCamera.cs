using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public GameObject player;       //Public variable to store a reference to the player game object

    [SerializeField]
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    private Vector3 toBePosition;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        // offset = transform.position - player.transform.position;
       // transform.position = player.transform.position;// + offset;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.

        if(DataManager.isMultiplayer)
        {
            toBePosition = player.transform.position;
            if (toBePosition.x < -63)
            {
                toBePosition.x = -63;
            }
            if (toBePosition.x > 133)
            {
                toBePosition.x = 133;
            }
            transform.position = Vector3.Lerp(transform.position, toBePosition + offset, 0.04f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 0.04f);
        }
    }
}
