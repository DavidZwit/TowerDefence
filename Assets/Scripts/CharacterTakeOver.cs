using UnityEngine;
using System.Collections;

public class CharacterTakeOver : MonoBehaviour {
    private Selected selected;
    private Vector2 mousePos;
    private GameObject moveObject;
    private int moveSpeed = 10;
    private bool mouseDown;
    private int targetType;

    void Awake()
    {
        selected = GetComponent<Selected>();
    }

	void SetControll (GameObject takeObject) {
        if (takeObject != null)
        {
            moveObject = takeObject;
            if (takeObject.name.Contains("Tower"))
            {
                targetType = 1;
            }
            else if (takeObject.name.Contains("Cat"))
            {
                targetType = 2;
            }
        }
	}

    void MouseCheck()
    {
        if (Input.GetMouseButton(0))
        {
            mouseDown = true;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else mouseDown = false;
    }

    void walk()
    {
        if (targetType == 2 && moveObject.transform.position.x != mousePos.x && moveObject.transform.position.y != mousePos.y) {
            moveObject.transform.position = Vector3.MoveTowards(moveObject.transform.position, new Vector3(mousePos.x, mousePos.y, mousePos.y / 100), moveSpeed);
        }
    }
	
	void Update () {
        
        MouseCheck();
        walk();
	    SetControll(selected.Target);
	}
}
