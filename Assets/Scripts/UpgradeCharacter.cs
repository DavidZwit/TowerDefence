using UnityEngine;
using System.Collections;

public class UpgradeCharacter : MonoBehaviour {
    private Resources resources;
    private Selected selected;

    void Awake()
    {
        resources = GameObject.Find("Handeler").GetComponent<Resources>();
        selected = GameObject.Find("Handeler").GetComponent<Selected>();
    }

    public void UpgradeHealth()
    {
        if (resources.Fish > 0) {
            if (selected.Target.name.Contains("Tower")) {
                GetComponent<TurretBase>().HealthUpgrade++;
            } else if (selected.Target.name.Contains("Cat")) {
                GetComponent<UnitBase>().HealthUpgrade++;
            } resources.Fish -= 2;
        }
    }

    public void UpgradeAttackSpeed()
    {
        if (resources.Fish > 0 && resources.Yarn > 0)
        {
            if (selected.Target.name.Contains("Tower")) {
                GetComponent<TurretBase>().AttackSpeedUpgrade++;
            } else if (selected.Target.name.Contains("Cat")) {
                GetComponent<UnitBase>().AttackSpeedUpgrade++;
            } resources.Fish--; resources.Yarn--;
        }
    }

    public void UpgradeAttackRange()
    {
        if (resources.Yarn > 0 && resources.Cardboard > 0) {
            if (selected.Target.name.Contains("Tower")) {
                GetComponent<TurretBase>().AttackRangeUpgrade++;
            } else if (selected.Target.name.Contains("Cat")) {
                GetComponent<UnitBase>().AttackRangeUpgrade++;
            } resources.Yarn--; resources.Cardboard--;
        }
    }

    public void UpgradeMaxTargets()
    {
        if (resources.Cardboard > 0 && resources.Yarn > 0) {
            if (selected.Target.name.Contains("Tower")) {
                GetComponent<TurretBase>().MaxTargetsUpgrade++;
            } else if (selected.Target.name.Contains("Cat")) {
                GetComponent<UnitBase>().MaxTargetsUpgrade++;
            } resources.Cardboard--; resources.Yarn--;

        }
    }
}