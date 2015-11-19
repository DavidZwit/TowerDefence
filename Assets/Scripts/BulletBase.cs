using UnityEngine;
using System.Collections;

public class BulletBase : MonoBehaviour {
    private int lifeTime = 100;
    private int damage = 10;
    private Vector2 target;

	void FixedUpdate () {

        lifeTime--;
        if (lifeTime <= 0) Destroy(this.gameObject);

        transform.position = Vector2.MoveTowards(transform.position, target, Vector2.Distance(transform.position, target)/15);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.SendMessage("ApplyDamage", damage);
            Destroy(this.gameObject);
        }
    }

    public Vector2 Target
    {
        get { return target; }
        set { target = value; }
    }
}
