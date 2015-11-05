using UnityEngine;
using System.Collections;

public class KayboardInput : MonoBehaviour {
    private Selected moveObject;

    void Awake()
    {
        moveObject = GameObject.Find("Handeler").GetComponent<Selected>();
    }

	void Update()
    {
        if (Input.GetKey(KeyCode.W))
            moveObject.Target.transform.position += new Vector3(0, 5, 0);
        if (Input.GetKey(KeyCode.A))
            moveObject.Target.transform.position += new Vector3(-5, 0, 0);
        if (Input.GetKey(KeyCode.D))
            moveObject.Target.transform.position += new Vector3(5, 0, 0);
        if (Input.GetKey(KeyCode.S))
            moveObject.Target.transform.position += new Vector3(0, -5, 0);
    }
}
