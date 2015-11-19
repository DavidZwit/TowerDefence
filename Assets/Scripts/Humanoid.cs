using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Humanoid : MonoBehaviour {
    [SerializeField] protected int health = 5;//The health of the object
    [SerializeField] protected int maxTargets = 1;//The amound of targets that can be attacked at once
    [SerializeField] protected int atackDamage = 5;//The dammage the attacks do
    [SerializeField] protected float atackSpeed = 2;//The speed the target can attacxk
    [SerializeField] protected int atackRange = 500;//Range object can atack from
    [SerializeField] protected Vector3 damagePosOffset;//The offset form the piffit point the damage is given
    [SerializeField] protected GameObject projectile = null;//Projectile
    protected int power;//The power, is to determen how strong the object is for sorting
    protected bool attacking, moving;//Says if object is atacking
    protected float nextFire;//fire rate handeler
    protected string targetTag;//The tag of the target to atack
    protected Animator animator;//Gets the animator object
    [SerializeField] protected GameObject[] targets;//The targets to atack
    protected SpriteRenderer renderer;
    protected bool inBattle, isFriendly;
    protected int attackingHash = Animator.StringToHash("attacking");

    protected void Awake()
    {
        if (gameObject.tag == "Enemy") { isFriendly = false; targetTag = "Friendly"; inBattle = true; }
        else if (gameObject.tag == "Friendly"){ isFriendly = true; targetTag = "Enemy";}
        if (GetComponent<Animator>() != null) animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    protected void Atack()
    {
        if (Time.time > nextFire)
        {
            targets = CheckTargets(atackRange);
            if (targets.Length > 0) {
                int checkLength;
                if (targets.Length > maxTargets) checkLength = maxTargets;
                else checkLength = targets.Length;
                //foreach (GameObject target in targets)
                for (var i = checkLength - 1; i >= 0; i-- )
                {
                    renderer.color = new Color(1f, 0f, 1f);
                    Invoke("resetColor", 0.01f);
                    attacking = true;  SetRotationPos(targets[i].transform.position, "attackPos");
                    if (projectile != null)
                    {
                        GameObject bullet = Instantiate(projectile, transform.position + damagePosOffset, Quaternion.identity) as GameObject;
                        bullet.GetComponent<BulletBase>().Target = targets[i].transform.position;
                        bullet.transform.parent = transform;
                    }
                    else
                    {
                        targets[i].SendMessage("ApplyDamage", atackDamage);
                        moving = false;  animator.SetBool("walking", moving);
                    }
                    if (animator != null) animator.SetTrigger("attacking");
                }
            }
            else {
                attacking = false;
                if (animator != null) {
                    animator.SetBool(attackingHash, attacking);
                    moving = true;  animator.SetBool("walking", moving);
                }
            }
            nextFire = Time.time + atackSpeed;
        }
    }

    protected GameObject[] CheckTargets(int range)
    {
        renderer.color = new Color(0f, 1f, 1f);
        Invoke("resetColor", 0.2f);
        List<GameObject> targets = new List<GameObject>();
        foreach (Collider2D coll in Physics2D.OverlapCircleAll(transform.position, range)){
            if (coll.gameObject.tag == targetTag){
                targets.Add(coll.gameObject);
            }
        } return targets.ToArray();
    }

    protected void SetRotationPos(Vector2 target, string setInteger)
    {
        //setting the variable for the animations to work.
        if (animator != null)
        {
            float rotation = calculateAngle(transform.position, target);
            int result;

            if (rotation > 225 && rotation < 315) result = 1;
            else if (rotation > 135 && rotation < 225) result = 2;
            else if (rotation > 45 && rotation < 135) result = 3;
            else if (rotation > 315 || rotation < 45) result = 4;
            else result = 0;

            animator.SetInteger(setInteger, result);
        }
    }

    protected float calculateAngle(Vector2 from, Vector2 to)
    {
        return (Mathf.Atan2(to.y - from.y, to.x - from.x) * 180 / Mathf.PI) + 180;
    }

    protected void resetColor()
    {
        renderer.color = new Color(1f, 1f, 1f, 1f);
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