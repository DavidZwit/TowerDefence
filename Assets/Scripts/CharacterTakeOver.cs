using UnityEngine;
using System.Collections;

public class CharacterTakeOver : MonoBehaviour {
    private Selected selected;
    private Vector2 mousePos;
    private GameObject moveObject;
    private bool mouseDown,  tookOne;
    private int moveSpeed, targetType;
    UnitBase unitScript;
    TurretBase turretScript;

    void Awake()
    {
        selected = GetComponent<Selected>();
    }

	int SetControll (GameObject takeObject) {
        if (takeObject != null) {
            moveObject = takeObject;
            if (takeObject.name.Contains("Tower")) {
                turretScript = moveObject.GetComponent<TurretBase>();
                turretScript.takenOver = true;
                return 1;
            } else if (takeObject.name.Contains("Cat")) {
                unitScript = moveObject.GetComponent<UnitBase>();
                unitScript.takenOver = true; moveSpeed = unitScript.moveSpeed;
                return 2;
            } else return 0;
        } else return 0;
	}

    public void StopTakingOver()
    {
        
    }

    public void TakeOver()
    {
        if (!tookOne)
        {
            targetType = SetControll(selected.Target);
            tookOne = true;
        } else {
            if (targetType == 1) turretScript.takenOver = false;
            else if (targetType == 2) unitScript.takenOver = false;
            tookOne = false;
        }
        
    }

    void MouseCheck()
    {
        if (Input.GetMouseButton(0)) {
            mouseDown = true;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        } else mouseDown = false;
    }

    void WalkTo(Vector3 goToPos)
    {
        if (moveObject.transform.position != goToPos)
            moveObject.transform.position = Vector3.MoveTowards(moveObject.transform.position, goToPos, moveSpeed);
    }
	
	void Update () {
        if (tookOne) {
            MouseCheck();
            if (targetType == 1) {
                if (mouseDown) turretScript.ShootToPos(mousePos);
            } else if (targetType == 2) {
                WalkTo(mousePos);
                unitScript.Atack();
            }
        }
        
	}
}
