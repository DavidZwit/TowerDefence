using UnityEngine;
using System.Collections;

public class GridDrag : MonoBehaviour {
    private GameObject moveObject;
    private Vector2 pz;
    private int gridSize = 128;

    private bool drag = false;
    
	void Update()
    {
        if (moveObject != null) drag = true;
        else drag = false;

        if (drag) Drag();
    }

    void Drag()
    {
        pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        pz.x = Mathf.Round(pz.x / gridSize) * gridSize;
        pz.y = Mathf.Round(pz.y / gridSize) * gridSize;

        if (moveObject != null) moveObject.transform.position = pz;
    }

    public GameObject MoveObject
    {
        get { return moveObject; }
        set { moveObject = value; }
    }
}
