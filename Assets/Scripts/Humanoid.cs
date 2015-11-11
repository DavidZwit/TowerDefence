using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Humanoid : MonoBehaviour {
    [SerializeField] protected int health = 5;
    [SerializeField] protected int atackDamage = 5;
    [SerializeField] protected int atackRange = 500;
    [SerializeField] protected int power = 1;
    [SerializeField] protected int maxTargets = 1;
    protected bool inBattle, isFriendly;
    [SerializeField] protected float atackSpeed = 2;
    protected float nextFire;
    protected string targetTag;
    [SerializeField] protected Vector3 damagePosOffset;
    [SerializeField] protected GameObject projectile = null;
    protected GameObject[] targets;

    protected void Awake()
    {
        if (gameObject.tag == "Enemy") { isFriendly = false; targetTag = "Friendly"; inBattle = true; }
        else if (gameObject.tag == "Friendly"){ isFriendly = true; targetTag = "Enemy";}
    }

    protected void Atack()
    {
        if (Time.time > nextFire) { 
            targets = CheckTargets(atackRange);

            foreach (GameObject target in targets)
            {
                if (projectile != null) {
                    GameObject bullet = Instantiate(projectile, transform.position+damagePosOffset, Quaternion.identity) as GameObject;
                    bullet.GetComponent<BulletBase>().Target = target.transform.position;
                    bullet.transform.parent = transform;
                } else if (target != null) {
                    target.SendMessage("ApplyDamage", atackDamage);
                }
            }
            nextFire = Time.time + atackSpeed;
        }
    }

    protected GameObject[] CheckTargets(int range)
    {
        List<GameObject> targets = new List<GameObject>();
        foreach (Collider2D coll in Physics2D.OverlapCircleAll(transform.position, range)){
            if (coll.gameObject.tag == targetTag){
                targets.Add(coll.gameObject);
            }
        } return targets.ToArray();
    }

    void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }

    public int Health
    {
        get { return health; }
        set{ health = value; if (health <= 0) Destroy(gameObject);}
    }

    public int Power
    {
        get { return power; }
        set { power = value; }
    }

    protected virtual void StartBattle()
    {
            inBattle = true;
            if (GetComponent<select>() == true)GetComponent<select>().EditMode = false;
    }

    protected virtual void StopBattle()
    {
            inBattle = false;
            if (GetComponent<select>() == true) GetComponent<select>().EditMode = true;
    }

    void OnEnable()
    {
        if (isFriendly)
        {
            EventHandeler.StartBattle += StartBattle;
            EventHandeler.StopBattle += StopBattle;
        }
    }

    void OnDiable()
    {
        EventHandeler.StartBattle -= StartBattle;
        EventHandeler.StopBattle -= StopBattle;
    }

    void OnDestroy()
    {
        EventHandeler.StartBattle -= StartBattle;
        EventHandeler.StopBattle -= StopBattle;
    }
}