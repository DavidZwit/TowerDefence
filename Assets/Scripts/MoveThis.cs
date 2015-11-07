using UnityEngine;
using System.Collections;

public class MoveThis : MonoBehaviour {

    private Selected selected;
    private SpriteRenderer SR;
    private float blink;

    void Awake()
    {
        selected = GameObject.Find("Handeler").GetComponent<Selected>();
        SR = GetComponent<SpriteRenderer>();
    }

    //Needs fixing
    void Update()
    {
        if (selected.Target != null)
        {
            SR.color = new Color(1f, 1f, 1f, 1f);
            transform.position = new Vector3(selected.Target.transform.position.x, selected.Target.transform.position.y, 5);
        }
        else SR.color = new Color(1f, 1f, 1f, 0f);

        if (blink <= 0) blink++;
        else if (blink >= 100) blink--;

        
    }
}
