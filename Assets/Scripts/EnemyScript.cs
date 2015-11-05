using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    private TargetScript targetGetter;

    void Awake()
    {
        targetGetter = GameObject.Find("Handeler").GetComponent<TargetScript>();
    }

    void Update()
    {
        if (targetGetter.Target != null)
            transform.position = Vector3.MoveTowards(transform.position, targetGetter.Target.transform.position, 2);
    }
}
