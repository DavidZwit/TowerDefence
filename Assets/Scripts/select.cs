using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class select : MonoBehaviour
{
    private bool editMode = true;

    private bool selected = false;
    private GridDrag editMouse;
    private Selected selectSetter;
    private GameObject selectTile, theObject, lastObject;
    private bool nothingSelected;

    void Awake()
    {
        editMouse = GameObject.Find("Handeler").GetComponent<GridDrag>();
        selectSetter = GameObject.Find("Handeler").GetComponent<Selected>();
        selectTile = GameObject.Find("SelectTile");
    }

    void Update()
    {
        //print(eventsystem.IsPointerOverGameObject());
        if (selected) selectTile.transform.position = transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            nothingSelected = false;
            try {
                theObject = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 1).gameObject;
            }
            catch {
                nothingSelected = true;
            }
            if (!nothingSelected && theObject.tag == "Friendly")
            {
                if (editMode) {
                    if (!selected) {
                        Select(theObject);
                        lastObject = theObject;
                    } else if (selected) {
                        deSelect();
                    }
                }  
            }
        }
    }

    public void Select(GameObject theObject)
    {
        selectSetter.Target = theObject;
        selected = true;

        selectTile.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    public void Drag(GameObject theObject)
    {
        editMouse.MoveObject = theObject;
    }

    public void Drag()
    {
        editMouse.MoveObject = theObject;
    }

    public void UnDrag()
    {
        editMouse.MoveObject = null;
    }

    public void deSelect()
    {
        selectSetter.Target = null;
        editMouse.MoveObject = null;
        selected = false;

        selectTile.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }

    void NotEditMode()
    {
        editMode = false;
    }

    void EditMode()
    {
        editMode = true;
    }

    void OnEnable()
    {
        EventHandeler.StartBattle += NotEditMode;
        EventHandeler.StopBattle += EditMode;
    }

    void OnDestroy ()
    {
        EventHandeler.StartBattle -= NotEditMode;
        EventHandeler.StopBattle -= EditMode;
    }

}
