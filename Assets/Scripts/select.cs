using UnityEngine;
using System.Collections;

public class select : MonoBehaviour
{
    private bool editMode = true;

    private bool inWave, selected;
    private GridDrag editMouse;
    private Selected selectSetter;
    private GameObject selectTile;

    void Awake()
    {
        editMouse = GameObject.Find("Handeler").GetComponent<GridDrag>();
        selectSetter = GameObject.Find("Handeler").GetComponent<Selected>();
        selectTile = GameObject.Find("SelectTile");
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

    void Update()
    {
        if (selected) selectTile.transform.position = transform.position;
    }

    public void Select()
    {
        selectSetter.Target = gameObject;
        editMouse.MoveObject = gameObject;
        selected = true;

        selectTile.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    public void deSelect()
    {
        selectSetter.Target = null;
        editMouse.MoveObject = null;
        selected = false;

        selectTile.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }

    public bool EditMode
    {
        get { return editMode; }
        set { editMode = value; }
    }
}
