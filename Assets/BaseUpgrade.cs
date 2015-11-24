using UnityEngine;
using System.Collections;

public class BaseUpgrade : MonoBehaviour {

    BaseBehaviour upgradeSet;
    int attackRange, attackSpeed, health;
    GameObject health1, health2, 
        attackSpeed1, attackSpeed2, 
        attackRange1, attackRange2;

    void Awake()
    {
        upgradeSet = GetComponent<BaseBehaviour>();
        health1 = GameObject.Find("health1"); health1.SetActive(false);
        health2 = GameObject.Find("health2"); health2.SetActive(false);
        attackSpeed1 = GameObject.Find("attackSpeed1"); attackSpeed1.SetActive(false);
        attackSpeed2 = GameObject.Find("attackSpeed2"); attackSpeed2.SetActive(false);
        attackRange1 = GameObject.Find("attackRange1"); attackRange1.SetActive(false);
        attackRange2 = GameObject.Find("attackRange2"); attackRange2.SetActive(false);
    }

    public void UpgradeHealth()
    {
        if (health == 0) {
            health++; upgradeSet.Health += 200; health1.SetActive(true);
        } else if (health == 1) {
            health++; upgradeSet.Health += 400;
            health1.SetActive(false); health2.SetActive(true);
        }
    }

    public void UpgradeAttackSpeed()
    {
        if (attackSpeed == 0) {
            attackSpeed++; upgradeSet.AttackSpeed -= 0.5f; attackSpeed1.SetActive(true);
        } else if (attackSpeed == 1) {
            attackSpeed++; upgradeSet.AttackSpeed -= 1f;
            attackSpeed1.SetActive(false); attackSpeed2.SetActive(true);
        }
    }

    public void UpgradeAttackRange()
    {
        if (attackRange == 0) {
            attackRange++; upgradeSet.AttackRange += 200; attackRange1.SetActive(true);
        } else if (attackRange == 1) {
            attackRange++; upgradeSet.AttackRange += 300;
            attackRange1.SetActive(false); attackRange2.SetActive(true);
        }
    }
}