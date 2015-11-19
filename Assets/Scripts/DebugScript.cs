using UnityEngine;
using System.Collections;

public class DebugScript : MonoBehaviour {
    [SerializeField]
    private Transform baseObject;

    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = (Mathf.Atan2(baseObject.position.y - transform.position.y, baseObject.position.x - transform.position.x) * 180 / Mathf.PI) + 180;
        print(angle);
    }
}
