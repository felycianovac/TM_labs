using UnityEngine;

public class EditorCamera : MonoBehaviour
{
    float cameraSpeedMinSize = 10.0f;
    float zoomSpeed = 5.0f;
    float cameraSizeMin = 5.0f;
    float cameraSizeMax = 25.0f;
    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        float zoom = Input.GetAxis("Mouse ScrollWheel");
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - zoom * zoomSpeed, cameraSizeMin, cameraSizeMax);
        float cameraSpeed = cameraSpeedMinSize * cam.orthographicSize / cameraSizeMin;

        Vector2 translation = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            translation.y += cameraSpeed;
        if (Input.GetKey(KeyCode.S))
            translation.y += -cameraSpeed;
        if (Input.GetKey(KeyCode.A))
            translation.x += -cameraSpeed;
        if (Input.GetKey(KeyCode.D))
            translation.x += cameraSpeed;

        translation *= Time.deltaTime;

        transform.Translate(translation);
    }
}