using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
    private Transform target;
    private int LifeTime = 200;
    
    void Update()
    {
        LifeTime--;
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 20);

            if (transform.position == target.position)
            {
                Destroy(this.gameObject);
                target.gameObject.GetComponent<EnemyScript>().Health--;
            }
        }
        else Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            print("YEAS FINALY!!");
            Destroy(this.gameObject);
            coll.gameObject.GetComponent<EnemyScript>().Health--;
        }
    }

    public Transform Target
    {
        get { return target; }
        set { target = value; }
    }
}
