using UnityEngine;
using System.Collections;

public class UpgradeCharacter : MonoBehaviour {
    private Resources resources;
    private Selected selected;
    private GameObject upgradeMaxTargetsButton, 
        upgradeMaxRangeButton, 
        upgradeMaxAttackSpeedButton, 
        upgradeMaxHealthButton,
        upgradeUI;

    void Awake()
    {
        resources = GameObject.Find("Handeler").GetComponent<Resources>();
        selected = GameObject.Find("Handeler").GetComponent<Selected>();
        upgradeMaxTargetsButton = GameObject.Find("MaxTargetsUpgrade");
        upgradeMaxRangeButton = GameObject.Find("AttackRangeUpgrade");
        upgradeMaxAttackSpeedButton = GameObject.Find("AttackSpeedUpgrade");
        upgradeMaxHealthButton = GameObject.Find("AttackSpeedUpgrade");
        
        upgradeUI = GameObject.Find("UpgradeCharacter");
    }
    //Sorry for the extremely ineficiente way of doing this, but i do not have lot's of time left for this project
    void FixedUpdate()
    {
        if (selected.Target != null)
        {
            upgradeUI.SetActive(true);
            if (resources.Fish <= 2) upgradeMaxHealthButton.SetActive(false); else upgradeMaxHealthButton.SetActive(true);
            if (resources.Fish <= 1 || resources.Yarn <= 1) upgradeMaxAttackSpeedButton.SetActive(false); else upgradeMaxAttackSpeedButton.SetActive(true);
            if (resources.Yarn <= 1 || resources.Cardboard <= 1) upgradeMaxRangeButton.SetActive(false); else upgradeMaxRangeButton.SetActive(true);
            if (resources.Cardboard <= 1 || resources.Yarn <= 1) upgradeMaxTargetsButton.SetActive(false); else upgradeMaxTargetsButton.SetActive(true);  
        } else upgradeUI.SetActive(false);
    }

    public void UpgradeHealth()
    {
        if (resources.Fish > 0) {
            if (selected.Target.name.Contains("Tower")) {
                selected.Target.gameObject.GetComponent<TurretBase>().HealthUpgrade++;
            } else if (selected.Target.name.Contains("Cat")) {
                selected.Target.gameObject.GetComponent<UnitBase>().HealthUpgrade++;
            } resources.Fish -= 2;
        }
    }

    public void UpgradeAttackSpeed()
    {
        if (resources.Fish > 0 && resources.Yarn > 0)
        {
            if (selected.Target.name.Contains("Tower")) {
                selected.Target.gameObject.GetComponent<TurretBase>().AttackSpeedUpgrade++;
            } else if (selected.Target.name.Contains("Cat")) {
                selected.Target.gameObject.GetComponent<UnitBase>().AttackSpeedUpgrade++;
            } resources.Fish--; resources.Yarn--;
        }
    }

    public void UpgradeAttackRange()
    {
        if (resources.Yarn > 0 && resources.Cardboard > 0) {
            if (selected.Target.name.Contains("Tower")) {
                selected.Target.gameObject.GetComponent<TurretBase>().AttackRangeUpgrade++;
            } else if (selected.Target.name.Contains("Cat")) {
                selected.Target.gameObject.GetComponent<UnitBase>().AttackRangeUpgrade++;
            } resources.Yarn--; resources.Cardboard--;
        }
    }

    public void UpgradeMaxTargets()
    {
        if (resources.Cardboard > 0 && resources.Yarn > 0) {
            if (selected.Target.name.Contains("Tower")) {
                selected.Target.gameObject.GetComponent<TurretBase>().MaxTargetsUpgrade++;
            } else if (selected.Target.name.Contains("Cat")) {
                selected.Target.gameObject.GetComponent<UnitBase>().MaxTargetsUpgrade++;
            } resources.Cardboard--; resources.Yarn--;

        }
    }
}