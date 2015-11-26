using UnityEngine;
using System.Collections;

public class UpgradeCharacter : MonoBehaviour {
    private Resources resources;

    void Awake()
    {
        resources = GameObject.Find("Handeler").GetComponent<Resources>();
    }

    public void UpgradeHealth()
    {
        if (gameObject.name == "Tower") {
            GetComponent<TurretBase>().HealthUpgrade++;
        } else if (gameObject.name == "Cat") {
            GetComponent<UnitBase>().HealthUpgrade++;
        } resources.Fish -= 2;
    }

    public void UpgradeAttackSpeed()
    {
        if (gameObject.name == "Tower") {
            GetComponent<TurretBase>().AttackSpeedUpgrade++;
        } else if (gameObject.name == "Cat") {
            GetComponent<UnitBase>().AttackSpeedUpgrade++;
        } resources.Fish--; resources.Yarn--;
    }

    public void UpgradeAttackRange()
    {
        if (gameObject.name == "Tower") {
            GetComponent<TurretBase>().AttackRangeUpgrade++;
        } else if (gameObject.name == "Cat") {
            GetComponent<UnitBase>().AttackRangeUpgrade++;
        } resources.Yarn--; resources.Cardboard--;
    }

    public void UpgradeMaxTargets()
    {
        if (gameObject.name == "Tower") {
            GetComponent<TurretBase>().MaxTargetsUpgrade++;
        } else if (gameObject.name == "Cat") {
            GetComponent<UnitBase>().MaxTargetsUpgrade++;
        } resources.Cardboard--; resources.Yarn--;
    }
}