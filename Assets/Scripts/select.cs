using UnityEngine;
using System.Collections;

public class select : MonoBehaviour
{
    private bool editMode = true;

    private bool inWave, selected;
    private GridDrag editMouse;
    private Selected selectSetter;
    private GameObject selectTile, theObject;
    private bool nothingSelected;

    void Awake()
    {
        editMouse = GameObject.Find("Handeler").GetComponent<GridDrag>();
        selectSetter = GameObject.Find("Handeler").GetComponent<Selected>();
        selectTile = GameObject.Find("SelectTile");
    }

    void Update()
    {
        if (selected) selectTile.transform.position = transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            nothingSelected = false;
            try {
                theObject = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 100).gameObject;
            }
            catch { nothingSelected = true; }
            if (!nothingSelected && theObject.tag == "Friendly")
            {
                if (editMode) {
                    if (!selected) {
                        Select();
                    } else if (selected) {
                        deSelect();
                    }
                }  else {
                    if (!selected) {
                        selectSetter.Target = theObject;
                        selected = true;
                    } else if (selected) {
                        selectSetter.Target = null;
                        selected = false;
                    }
                }
            }
        }
    }

    public void Select()
    {
        selectSetter.Target = theObject;
        editMouse.MoveObject = theObject;
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
