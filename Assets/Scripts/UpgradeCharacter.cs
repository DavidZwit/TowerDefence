using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeCharacter : MonoBehaviour {
    private Resources resources;
    private Selected selected;
    private bool activatedButtons, inWave;
    private Button upgradeMaxTargetsButton,
        upgradeRangeButton,
        upgradeAttackSpeedButton,
        upgradeHealthButton;
    private Text maxTargetsLevel,
        attackRangeLevel,
        attackSpeedLevel,
        healthUpgradeLevel;
    private GameObject upgradeUI, takeOverButton;
    private RangeCircleScript circleReset;
    private int health, attackRange, attackSpeed, maxTargets;


    void Awake()
    {
        resources = GameObject.Find("Handeler").GetComponent<Resources>();
        selected = GameObject.Find("Handeler").GetComponent<Selected>();
        upgradeMaxTargetsButton = GameObject.Find("MaxTargetsUpgrade").GetComponent<Button>();
        maxTargetsLevel = GameObject.Find("MaxTargtsUpgradeText").GetComponent<Text>();

        upgradeRangeButton = GameObject.Find("AttackRangeUpgrade").GetComponent<Button>();
        attackRangeLevel = GameObject.Find("AttackRangeUpgradeText").GetComponent<Text>();

        upgradeAttackSpeedButton = GameObject.Find("AttackSpeedUpgrade").GetComponent<Button>();
        attackSpeedLevel = GameObject.Find("AttackSpeedUpgradeText").GetComponent<Text>();

        upgradeHealthButton = GameObject.Find("HealthUpgrade").GetComponent<Button>();
        healthUpgradeLevel = GameObject.Find("HealthUpgradeText").GetComponent<Text>();
        
        upgradeUI = GameObject.Find("UpgradeCharacter");
        circleReset = GameObject.Find("RangeCircles").GetComponent<RangeCircleScript>();

        takeOverButton = GameObject.Find("TakeOver");
    }
    //Sorry for the extremely ineficiente way of doing this, but i do not have lot's of time left for this project
    void FixedUpdate()
    {
        if (!inWave) {
            if (selected.Target == null) {
                upgradeUI.SetActive(false);
                activatedButtons = false;
            } else if (!activatedButtons) {
                activatedButtons = true;
                UpdateButtons();
            }
        } else {
            upgradeUI.SetActive(false);
            activatedButtons = false;
            if (selected.Target != null) {
                takeOverButton.SetActive(true);
            } else takeOverButton.SetActive(false);
        } 
    }

    private void UpdateButtons()
    {
        if (!EventHandeler.pause) { 
        upgradeUI.SetActive(true);
        if (selected.Target.name.Contains("Tower")) {
            TurretBase script = selected.Target.gameObject.GetComponent<TurretBase>();
            health = script.HealthUpgradeCount;
            attackRange = script.AttackRangeUpgradeCount;
            attackSpeed = script.AttackspeedUpgradeCount;
            maxTargets = script.TargetUpgradeCount;
        } else if (selected.Target.name.Contains("Cat")) {
            UnitBase script = selected.Target.gameObject.GetComponent<UnitBase>();
            health = script.HealthUpgradeCount;
            attackRange = script.AttackRangeUpgradeCount;
            attackSpeed = script.AttackspeedUpgradeCount;
            maxTargets = script.TargetUpgradeCount;
        } else if (selected.Target.name == "Base") {
            BaseBehaviour script = selected.Target.gameObject.GetComponent<BaseBehaviour>();
            health = script.HealthUpgradeCount;
            attackRange = script.AttackRangeUpgradeCount;
            attackSpeed = script.AttackspeedUpgradeCount;
            maxTargets = script.TargetUpgradeCount;
        }

        maxTargetsLevel.text = "UpgradeMaxStargets" + maxTargets;
        attackRangeLevel.text = "UpgradeRange" + attackRange;
        attackSpeedLevel.text = "UpgradeAttackSpeed" + attackSpeed;
        healthUpgradeLevel.text = "UpgradeHealth" + health;

        if (resources.Fish <= 2 || health >= 10) upgradeHealthButton.interactable = false; else upgradeHealthButton.interactable = true;
        if (resources.Fish <= 1 || resources.Yarn <= 1 || attackSpeed <= 0) upgradeAttackSpeedButton.interactable = false; else upgradeAttackSpeedButton.interactable = true;
        if (resources.Yarn <= 1 || resources.Cardboard <= 1 || attackRange >= 10) upgradeRangeButton.interactable = false; else upgradeRangeButton.interactable = true;
        if (resources.Cardboard <= 1 || resources.Yarn <= 1 || maxTargets >= 10) upgradeMaxTargetsButton.interactable = false; else upgradeMaxTargetsButton.interactable = true;
        }
    }

    public void UpgradeHealth()
    {
        if (resources.Fish > 0) {
            SoundManager.PlayAudio(7, 1);
            if (selected.Target.name.Contains("Tower")) {
                selected.Target.gameObject.GetComponent<TurretBase>().HealthUpgrade++; UpdateButtons();
            } else if (selected.Target.name.Contains("Cat")) {
                selected.Target.gameObject.GetComponent<UnitBase>().HealthUpgrade++; UpdateButtons();
            } else if (selected.Target.name == "Base") {
                selected.Target.gameObject.GetComponent<BaseBehaviour>().HealthUpgrade++; UpdateButtons();
            } resources.Fish -= 2;
        }
    }

    public void UpgradeAttackSpeed()
    {
        if (resources.Fish > 0 && resources.Yarn > 0)
        {
            SoundManager.PlayAudio(7, 1);
            if (selected.Target.name.Contains("Tower")) {
                selected.Target.gameObject.GetComponent<TurretBase>().AttackSpeedUpgrade++; UpdateButtons();
            } else if (selected.Target.name.Contains("Cat")) {
                selected.Target.gameObject.GetComponent<UnitBase>().AttackSpeedUpgrade++; UpdateButtons();
            } else if (selected.Target.name == "Base") {
                selected.Target.gameObject.GetComponent<BaseBehaviour>().AttackSpeedUpgrade++; UpdateButtons();
            } resources.Fish--; resources.Yarn--;
        }
    }

    public void UpgradeAttackRange()
    {
        circleReset.checkedRange = false;
        if (resources.Yarn > 0 && resources.Cardboard > 0) {
            SoundManager.PlayAudio(7, 1);
            if (selected.Target.name.Contains("Tower")) {
                selected.Target.gameObject.GetComponent<TurretBase>().AttackRangeUpgrade++; UpdateButtons();
            } else if (selected.Target.name.Contains("Cat")) {
                selected.Target.gameObject.GetComponent<UnitBase>().AttackRangeUpgrade++; UpdateButtons();
            } else if (selected.Target.name == "Base") {
                selected.Target.gameObject.GetComponent<BaseBehaviour>().AttackRangeUpgrade++; UpdateButtons();
            } resources.Yarn--; resources.Cardboard--;
        }
    }

    public void UpgradeMaxTargets()
    {
        if (resources.Cardboard > 0 && resources.Yarn > 0) {
            SoundManager.PlayAudio(7, 1);
            if (selected.Target.name.Contains("Tower")) {
                selected.Target.gameObject.GetComponent<TurretBase>().MaxTargetsUpgrade++; UpdateButtons();
            } else if (selected.Target.name.Contains("Cat")) {
                selected.Target.gameObject.GetComponent<UnitBase>().MaxTargetsUpgrade++; UpdateButtons();
            } else if (selected.Target.name == "Base") {
                selected.Target.gameObject.GetComponent<BaseBehaviour>().MaxTargetsUpgrade++; UpdateButtons();
            } resources.Cardboard--; resources.Yarn--;
        }
    }

    void StartWave()
    {
        inWave = true;
    }

    void StopWave()
    {
        inWave = false;
    }

    void OnEnable()
    {
        EventHandeler.StartBattle += StartWave;
        EventHandeler.StopBattle += StopWave;
    }

    void OnDestroy()
    {
        EventHandeler.StartBattle -= StartWave;
        EventHandeler.StopBattle -= StopWave;
    }
}