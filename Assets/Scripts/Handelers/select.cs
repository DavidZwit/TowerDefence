using UnityEngine;
using System.Collections;

public class select : MonoBehaviour
{
    private bool placed = true;
    private bool empty = true;
    private bool editMode = true;

    private bool inWave, selected;
    private GridDrag editMouse;
    private Selected selectSetter;
    private GameObject SelectTile;

    void Awake()
    {
        editMouse = GameObject.Find("Handeler").GetComponent<GridDrag>();
        selectSetter = GameObject.Find("Handeler").GetComponent<Selected>();
        SelectTile = GameObject.Find("SelectTile");
    }

    void OnMouseDown()
    {
        if (editMode)
        {
            if (!selected)
            {
               selectSetter.Target = gameObject; selected = true;
            } 
            else if (selected)
            {
                selectSetter.Target = null; selected = false;
            }
        }
    }

    public bool EditMode
    {
        get { return editMode; }
        set { editMode = value; }
    }
}
