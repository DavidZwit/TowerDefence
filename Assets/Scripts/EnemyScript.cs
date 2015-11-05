using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    private Selected targetGetter;
    private int health = 5;

    public void Awake()
    {
        targetGetter = GameObject.Find("Handeler").GetComponent<Selected>();
    }

    void Update()
    {
        if (targetGetter.Target != null)
            transform.position = Vector3.MoveTowards(transform.position, targetGetter.Target.transform.position, 2);
    }

    public int Health
    {
        get { return health; }
        set { health = value; 
        if (health <= 0) Destroy(this.gameObject);
        }
    }
}
