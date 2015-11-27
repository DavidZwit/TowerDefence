using UnityEngine;
using System.Collections;

public class BaseBehaviour : TurretBase {
    private GameObject health1, health2, health3,
        attackSpeed1, attackSpeed2, attackSpeed3,
        attackRange1, attackRange2, attackRange3;
    private bool died;

    new void Awake()
    {
        health1 = GameObject.Find("health1"); health1.SetActive(false);
        health2 = GameObject.Find("health2"); health2.SetActive(false);
        health3 = GameObject.Find("health3"); health3.SetActive(false);
        attackSpeed1 = GameObject.Find("attackSpeed1"); attackSpeed1.SetActive(false);
        attackSpeed2 = GameObject.Find("attackSpeed2"); attackSpeed2.SetActive(false);
        attackSpeed3 = GameObject.Find("attackSpeed3"); attackSpeed3.SetActive(false);
        attackRange1 = GameObject.Find("attackRange1"); attackRange1.SetActive(false);
        attackRange2 = GameObject.Find("attackRange2"); attackRange2.SetActive(false);
        attackRange3 = GameObject.Find("attackRange3"); attackRange3.SetActive(false);
        base.Awake();
    }

    private void Update()
    {
        if (endGame && !died) {
            died = true;
            animator.Play(dieAnim.name);
            Invoke("EndGame", dieAnim.length);
            Destroy(gameObject, dieAnim.length);
        }
    }

    void EndGame()
    {
        EventHandeler.pause = true;
        GameObject.Find("Handeler").GetComponent<EventHandeler>().EndGame();
    }

    public override int AttackRangeUpgrade
    {
        get { return base.AttackRangeUpgrade; }
        set {
            if (AttackRangeUpgradeCount == 2) {
                attackRange1.SetActive(true);
            }  else if (AttackRangeUpgradeCount == 5) {
                attackRange1.SetActive(false); attackRange2.SetActive(true);
            }  else if (AttackRangeUpgradeCount == 9) {
                attackRange2.SetActive(false); attackRange3.SetActive(true);
            }
            base.AttackRangeUpgrade = value; 
        }
    }

    public override float AttackSpeedUpgrade
    {
        get { return base.AttackSpeedUpgrade; }
        set
        {
            if (AttackspeedUpgradeCount == 2) {
                attackSpeed1.SetActive(true);
            } else if (AttackspeedUpgradeCount == 5) {
                attackSpeed1.SetActive(false); attackSpeed2.SetActive(true);
            } else if (AttackspeedUpgradeCount == 9) {
                attackSpeed2.SetActive(false); attackSpeed3.SetActive(true);
            }
            base.AttackSpeedUpgrade = value;
        }
    }

    public override int HealthUpgrade
    {
        get { return base.HealthUpgrade; }
        set {
            if (HealthUpgradeCount == 2) {
                health1.SetActive(true);
            } else if (HealthUpgradeCount == 5) {
                health1.SetActive(false); health2.SetActive(true);
            } else if (HealthUpgradeCount == 9) {
                health2.SetActive(false); health3.SetActive(true);
            }
            base.HealthUpgrade = value;
        }
    }
}
