using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    float minZoomDistance;
    float maxZoomDistance;

    Vector3 velocity = new Vector3(0, 0, 0);
    Vector3 mouseDelta = new Vector3(0, 0, 0);
    bool dragging = false;

    Vector2 cameraSize = new Vector2(0, 0);

    [SerializeField]
    public Transform map;
    [SerializeField]
    public Camera mainCamera;

    float getMaxCameraSize(Vector2 resolution)
    {
        float smallestRatio = Mathf.Min(
            Mathf.Abs((resolution.x - 10) / mainCamera.aspect),
            Mathf.Abs(resolution.y - 10)
        );

        return smallestRatio / 2;
    }

    // Use this for initialization
    void Start()
    {
        cameraSize.y = Screen.height;
        cameraSize.x = Screen.width;

        maxZoomDistance = getMaxCameraSize(map.transform.localScale);
        minZoomDistance = getMaxCameraSize(cameraSize);

        Camera.main.orthographicSize = maxZoomDistance;
    }

    // Update is called once per frame
    void Update()
    {
        cameraSize.y = 2f * mainCamera.orthographicSize;
        cameraSize.x = cameraSize.y * mainCamera.aspect;


        mouseDelta.x = Input.GetAxis("Mouse X") * 4;
        mouseDelta.y = Input.GetAxis("Mouse Y") * 4;
        velocity.z -= Input.mouseScrollDelta.y * 4;


        if (Input.GetMouseButton(0) && (mouseDelta.sqrMagnitude > 0 || dragging))
        {
            dragging = true;
            velocity -= mouseDelta;
        }
        else dragging = false;

        
        transform.position += new Vector3(velocity.x, velocity.y, 0);


        if (Camera.main.orthographicSize > maxZoomDistance)
            Camera.main.orthographicSize = maxZoomDistance;
        if (Camera.main.orthographicSize < minZoomDistance)
            Camera.main.orthographicSize = minZoomDistance;

        if (transform.position.x - cameraSize.x / 2 < map.position.x - map.localScale.x / 2)
            transform.position = new Vector2(map.position.x - map.localScale.x / 2 + cameraSize.x / 2, transform.position.y);

        if (transform.position.x + cameraSize.x / 2 > map.position.x + map.localScale.x / 2)
            transform.position = new Vector2(map.position.x + map.localScale.x / 2 - cameraSize.x / 2, transform.position.y);

        if (transform.position.y - cameraSize.y / 2 < map.position.y - map.localScale.y / 2)
            transform.position = new Vector2(transform.position.x, map.position.y - map.localScale.y / 2 + cameraSize.y / 2);

        if (transform.position.y + cameraSize.y / 2 > map.position.y + map.localScale.y / 2)
            transform.position = new Vector2(transform.position.x, map.position.y + map.localScale.y / 2 - cameraSize.y / 2);



        Camera.main.orthographicSize += velocity.z;
        velocity -= velocity / 10;
    }
}
