using UnityEngine;
using System.Collections;

public class select : MonoBehaviour
{
    private bool editMode = true;

    private bool inWave, selected;
    private GridDrag editMouse;
    private Selected selectSetter;

    void Awake()
    {
        editMouse = GameObject.Find("Handeler").GetComponent<GridDrag>();
        selectSetter = GameObject.Find("Handeler").GetComponent<Selected>();
    }

    void OnMouseDown()
    {
        if (editMode)
        {
            if (!selected)
            {
                Select();
            } 
            else if (selected)
            {
                deSelect();
            }
        }
    }

    public void Select()
    {
        selectSetter.Target = gameObject;
        editMouse.MoveObject = gameObject;
        selected = true;
    }

    public void deSelect()
    {
        selectSetter.Target = null;
        editMouse.MoveObject = null;
        selected = false;
    }

    public bool EditMode
    {
        get { return editMode; }
        set { editMode = value; }
    }
}
