using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    float minZoomDistance = 10;
    float maxZoomDistance;

    Vector3 velocity = new Vector3(0, 0, 0);
    Vector3 mouseDelta = new Vector3(0, 0, 0);
    bool dragging = false;

    Vector2 cameraSize = new Vector2(0, 0);

    public Transform map;
    public Camera mainCamera;

    float getMaxCameraSize ( Vector2 resolution )
    {
        float smallestRatio = Mathf.Min(
            Mathf.Abs((resolution.x - 10) / mainCamera.aspect),
            Mathf.Abs(resolution.y - 10)
        );

        return smallestRatio / 2;
    }

    // Use this for initialization
    void Start () {
        mainCamera = Camera.main;

        cameraSize.y = 2f * mainCamera.orthographicSize;
        cameraSize.x = cameraSize.y * mainCamera.aspect;

        maxZoomDistance = getMaxCameraSize(map.transform.localScale);
        minZoomDistance = getMaxCameraSize(new Vector2(Screen.width, Screen.height));

        mainCamera.orthographicSize = maxZoomDistance;
    }
	
	// Update is called once per frame
    void FixedUpdate ()
    {

        maxZoomDistance = getMaxCameraSize(map.transform.localScale);
        minZoomDistance = getMaxCameraSize(new Vector2(Screen.width, Screen.height));
    }
	void Update ()
    {
        mainCamera.transform.localScale = cameraSize;

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

        velocity -= velocity / 10;


        mainCamera.orthographicSize += velocity.z;

        cameraSize.y = 2f * mainCamera.orthographicSize;
        cameraSize.x = cameraSize.y * mainCamera.aspect;

        if (mainCamera.orthographicSize > maxZoomDistance) {
            mainCamera.orthographicSize = maxZoomDistance;
            velocity.z = 0;
        }
        if (mainCamera.orthographicSize < minZoomDistance) {
            mainCamera.orthographicSize = minZoomDistance;
            velocity.z = 0;
        }

        if (transform.position.x - cameraSize.x / 2 < map.position.x - map.localScale.x / 2)
            transform.position = new Vector2(map.position.x - map.localScale.x / 2 + cameraSize.x / 2, transform.position.y);

        if (transform.position.x + cameraSize.x / 2 > map.position.x + map.localScale.x / 2)
            transform.position = new Vector2(map.position.x + map.localScale.x / 2 - cameraSize.x / 2, transform.position.y);

        if (transform.position.y - cameraSize.y / 2 < map.position.y - map.localScale.y / 2)
            transform.position = new Vector2(transform.position.x, map.position.y - map.localScale.y / 2 + cameraSize.y / 2);

        if (transform.position.y + cameraSize.y / 2 > map.position.y + map.localScale.y / 2)
            transform.position = new Vector2(transform.position.x, map.position.y + map.localScale.y / 2 - cameraSize.y / 2);



    }
}
