using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour {
    private Vector2 mp;

    void Start()
    {
        Cursor.visible = false;
    }

	void FixedUpdate () {
        mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        gameObject.transform.position = mp;
	}
}
