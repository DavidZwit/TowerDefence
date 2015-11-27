using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Humanoid : MonoBehaviour
{
    [SerializeField] protected int health = 5;//The health of the object
    private int maxHealth = 0;//The health of the object
    [SerializeField] protected int maxTargets = 1;//The amound of targets that can be attacked at once
    [SerializeField] protected int atackDamage = 5;//The dammage the attacks do
    [SerializeField] protected float atackSpeed = 2;//The speed the target can attacxk
    [SerializeField] public int atackRange = 500;//Range object can atack from
    [SerializeField] protected Vector3 damagePosOffset;//The offset form the piffit point the damage is given
    [SerializeField] protected GameObject projectile = null;//Projectile
    [SerializeField] private float attackSpeedUpgrade;//How fast these things upgrade
    [SerializeField] private int targetsUpgrade, attackRange, healthUpgrade;//How fast these things upgrade
    [SerializeField] private GameObject healthBar;//The Healthbar GUI
    [SerializeField] private TextMesh healthBarText;//The Healthbar TEXT
    [SerializeField] protected AnimationClip dieAnim, buildAnim;
    protected int healthbarSize;//The max health of the object
    private int targetUpgradeCount, attackRangeUpgradeCount, healthUpgradeCount, attackspeedUpgradeCount;
    protected int power;//The power, is to determen how strong the object is for sorting
    protected float nextFire;//fire rate handeler
    protected string targetTag;//The tag of the target to atack
    protected Animator animator;//Gets the animator object
    protected GameObject[] targets;//The targets to atack
    protected bool attacking, moving;//Says if object is atacking
    protected bool inBattle, isFriendly;

    protected void Awake()
    {
        maxHealth = health;
        if (healthBar) healthbarSize = (int)healthBar.transform.localScale.x;
        if (gameObject.tag == "Enemy") { isFriendly = false; targetTag = "Friendly"; inBattle = true; }
        else if (gameObject.tag == "Friendly"){ isFriendly = true; targetTag = "Enemy";}
        if (GetComponent<Animator>() != null) { animator = GetComponent<Animator>(); }
        if (buildAnim != null) animator.Play(buildAnim.name); Invoke("StartAnimations", buildAnim.length);

        updateHealthBar();
    }

    protected void Atack()
    {
        if (Time.time > nextFire) //using the fire rate
        {
            targets = CheckTargets(atackRange);

            if (targets.Length > 0) {
                //Using the max target var
                int checkLength;
                if (targets.Length > maxTargets) checkLength = maxTargets;
                else checkLength = targets.Length;
                //Attacking all the targets that need to be attacked
                for (var i = checkLength - 1; i >= 0; i-- )
                {
                    //Setting animation variables
                    attacking = true;  SetRotationPos(targets[i].transform.position, "attackPos");

                    if (projectile != null) { //if it is an turret
                        GameObject bullet = Instantiate(projectile, transform.position + damagePosOffset, Quaternion.identity) as GameObject;
                        bullet.GetComponent<BulletBase>().Target = targets[i].transform.position;
                        bullet.transform.parent = transform;
                    } else { //if it is an ground unit that can not shoot
                        targets[i].SendMessage("ApplyDamage", atackDamage, SendMessageOptions.DontRequireReceiver);
                        moving = false;  animator.SetBool("walking", false);
                    }
                    if (animator != null) animator.SetTrigger("attacking");
                }
            } else { // if ther is nothing to attack
                attacking = false;
                if (animator != null) {
                    moving = true;  if (!isFriendly) animator.SetBool("walking", true);
                }
            }
            nextFire = Time.time + atackSpeed;
        }
    }

    protected GameObject[] CheckTargets(int range)
    {
        //Grabbing all the targets and puting them in an array
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

            if (rotation > 45 && rotation < 135) result = 1;
            else if (rotation > 135 && rotation < 225) result = 2;
            else if (rotation > 225 && rotation < 315) result = 3;
            else if (rotation > 315 || rotation < 45) result = 4;
            else result = 0;

            animator.SetInteger(setInteger, result);
        }
    }

    protected float calculateAngle(Vector2 from, Vector2 to)
    {
        return (Mathf.Atan2(to.y - from.y, to.x - from.x) * 180 / Mathf.PI) + 180;
    }

    private void updateHealthBar()
    {
        try { animator.SetInteger("Health", (health / 100) * maxHealth); } catch { };

        if (healthBar)
            healthBar.transform.localScale = new Vector3(((float)health / (float)maxHealth) * healthbarSize, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        if (healthBarText)
            healthBarText.text = health.ToString();
    }

    void StartAnimations()
    {
        animator.SetInteger("attackPos", 1);
    }

    //Upgrade get and setters
    public virtual float AttackSpeedUpgrade
    {
        get { return atackSpeed; }
        set
        {
            attackspeedUpgradeCount++;
            if (atackSpeed > 0) atackSpeed -= (attackSpeedUpgrade); }
    }

    public virtual int AttackRangeUpgrade
    {
        get { return atackRange; }
        set
        {   attackRangeUpgradeCount++;
            atackRange += (AttackRangeUpgrade); }
    }

    public virtual int HealthUpgrade
    {
        get { return Health; }
        set
        {
            healthUpgradeCount++;
            health += (healthUpgrade);
            if (health > maxHealth) maxHealth = health;
            updateHealthBar();
        }
    }

    public virtual int MaxTargetsUpgrade
    {
        get { return maxTargets; }
        set
        {
            maxTargets++;
            maxTargets -= (targetsUpgrade);
        }
    }

    //Getters and setters for geting the upgraded amound

    public int TargetUpgradeCount
    {
        get { return targetUpgradeCount; }
        set { targetUpgradeCount = value; }
    }

    public int AttackRangeUpgradeCount
    {
        get { return attackRangeUpgradeCount; }
        set { attackRangeUpgradeCount = value; }
    }

    public int HealthUpgradeCount
    {
        get { return healthUpgradeCount; }
        set { healthUpgradeCount = value; }
    }

    public int AttackspeedUpgradeCount
    {
        get { return attackspeedUpgradeCount; }
        set { attackspeedUpgradeCount = value; }
    }

    //Dealling damage and adding health
    protected void ApplyDamage(int damage)
    {
        health -= damage;
        updateHealthBar();
        if (health <= 0) Die();
    }

    public int Health
    {
        get { return health; }
        set
        {
            health = value; if (health <= 0) Die();
            updateHealthBar();
        }
    }

    protected void Die()
    {
        if (GetComponent<Animation>())
        {
            animator.Play(dieAnim.name);
            Destroy(gameObject, dieAnim.length);
        }
        else Destroy(gameObject);
    }
    //Stuff to controll the events, don't really worry about it.

    protected virtual void StartBattle()
    {
        inBattle = true;
    }

    protected virtual void StopBattle()
    {
        inBattle = false;
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