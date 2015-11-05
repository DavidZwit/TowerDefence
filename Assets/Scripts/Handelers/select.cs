using UnityEngine;
using System.Collections;

public class select : MonoBehaviour
{
    private bool placed = true;
    private bool empty = true;
    private bool editMode = true;

    private bool inWave, selected;
    private GridDrag editMouse;
    private Selected targetSetter;
    private GameObject SelectTile;

    void Awake()
    {
        editMouse = GameObject.Find("Handeler").GetComponent<GridDrag>();
        targetSetter = GameObject.Find("Handeler").GetComponent<Selected>();
        SelectTile = GameObject.Find("SelectTile");
    }

    void OnMouseDown()
    {
        if (editMode)
        {
            if (placed)
            {
                editMouse.MoveObject = gameObject; placed = false; selected = false;

            }
            else if (empty)
            {
                targetSetter.Target = this.gameObject; selected = true;
                editMouse.MoveObject = null; placed = true;
            }
        }
    }

    public bool EditMode
    {
        get { return editMode; }
        set { editMode = value; }
    }
}
