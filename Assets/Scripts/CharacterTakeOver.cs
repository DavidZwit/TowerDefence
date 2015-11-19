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
        if (mouseDown && targetType == 2) {
            moveObject.transform.position = Vector2.MoveTowards(moveObject.transform.position, mousePos, moveSpeed);
        }
    }
	
	void Update () {
        
        MouseCheck();
        walk();
	    SetControll(selected.Target);
	}
}
