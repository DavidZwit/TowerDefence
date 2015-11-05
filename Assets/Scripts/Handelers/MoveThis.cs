using UnityEngine;
using System.Collections;

public class MoveThis : MonoBehaviour {

    private GridDrag gridScript;
    private SpriteRenderer SR;
    private float blink;

    void Awake()
    {
        gridScript = GameObject.Find("Handeler").GetComponent<GridDrag>();
        SR = GetComponent<SpriteRenderer>();
    }

    //Needs fixing
    void Update()
    {
        if (gridScript.MoveObject != null)
        {
            SR.color = new Color(1f, 1f, 1f, 1f);
            transform.position = new Vector3(gridScript.MoveObject.transform.position.x, gridScript.MoveObject.transform.position.y, 50);
        }
        else SR.color = new Color(1f, 1f, 1f, 0f);

        if (blink <= 0) blink++;
        else if (blink >= 100) blink--;

        
    }
}
