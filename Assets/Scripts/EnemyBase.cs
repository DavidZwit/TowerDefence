using UnityEngine;
using System.Collections;

public class EnemyBase : CharactersBase {
    private float nextHit;
    private int health = 5;

    protected virtual void Start()
    {
        inBattle = true;
        targetTag = "Friendly";
        fallBackSpot = GameObject.Find("Base").transform.position;
        target = fallBackSpot;
    }

    protected override void Update()
    {
        base.Update();
        transform.position = Vector3.MoveTowards(transform.position, target, 10);
        if (hitTarget && damageTarget != null) damageTarget.SendMessage("ApplyDamage", 2);
    }

    void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }

    public int Health
    {
        get { return health; }
        set { health = value; 
        if (health <= 0) Destroy(gameObject);
        }
    }
}
