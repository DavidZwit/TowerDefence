using UnityEngine;
using System.Collections;

public class BaseBehaviour : TurretBase {
    private GameObject health1, health2,
        attackSpeed1, attackSpeed2,
        attackRange1, attackRange2;

    private int healthTimes,
        attackSpeedTimes,
        attackRangeTimes;

    new void Awake()
    {
        health1 = GameObject.Find("health1"); health1.SetActive(false);
        health2 = GameObject.Find("health2"); health2.SetActive(false);
        attackSpeed1 = GameObject.Find("attackSpeed1"); attackSpeed1.SetActive(false);
        attackSpeed2 = GameObject.Find("attackSpeed2"); attackSpeed2.SetActive(false);
        attackRange1 = GameObject.Find("attackRange1"); attackRange1.SetActive(false);
        attackRange2 = GameObject.Find("attackRange2"); attackRange2.SetActive(false);
        base.Awake();
    }

    public override int AttackRangeUpgrade
    {
        get { return base.AttackRangeUpgrade; }
        set {
            if (healthTimes == 0) {
                healthTimes++; health1.SetActive(true);
            }
            else if (healthTimes == 1) {
                healthTimes++; health1.SetActive(false); health2.SetActive(true);
            }
            base.AttackRangeUpgrade = value; 

        }
    }

    public override float AttackSpeedUpgrade
    {
        get { return base.AttackSpeedUpgrade; }
        set
        {
            if (attackSpeedTimes == 0) {
                attackSpeedTimes++; attackSpeed1.SetActive(true);
            } else if (attackSpeedTimes == 1) {
                attackSpeedTimes++; attackSpeed1.SetActive(false); attackSpeed2.SetActive(true);
            }
            base.AttackSpeedUpgrade = value;
        }
    }

    public override int HealthUpgrade
    {
        get { return base.HealthUpgrade; }
        set {
            if (healthTimes == 0) {
                healthTimes++; health1.SetActive(true);
            }
            else if (healthTimes == 1) {
                healthTimes++; health1.SetActive(false); health2.SetActive(true);
            }
            base.HealthUpgrade = value;
        }
    }
}
