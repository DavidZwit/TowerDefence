using UnityEngine;
using System.Collections;

public class select : MonoBehaviour {
    private bool placed = true;
    private bool empty = true;

    private bool inWave, selected;
    private EditorMouse editMouse;
    private TargetScript targetSetter;

    void Awake()
    {
        editMouse = GameObject.Find("Handeler").GetComponent<EditorMouse>();
        targetSetter = GameObject.Find("Handeler").GetComponent<TargetScript>();
    }

    void OnMouseDown()
    {
        if (placed)
        {
            editMouse.MoveObject = gameObject; placed = false;
        }
        else if (empty)
        {
            targetSetter.Target = this.gameObject;  selected = true;
            editMouse.MoveObject = null; placed = true;
        }
    }
}
