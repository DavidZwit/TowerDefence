using UnityEngine;
using System.Collections;

public class RangeCircleScript : MonoBehaviour {
    float size = 200;
    public bool checkedRange, turnedOf;
    Selected selected;
    GameObject lookRange, attackRange;

    void Awake()
    {
        selected = GameObject.Find("Handeler").GetComponent<Selected>();
        lookRange = GameObject.Find("LookRangeCircle");
        attackRange = GameObject.Find("RangeCircle");
    }

    private void Update()
    {
        if (selected.Target)
        {
            attackRange.transform.position = selected.Target.transform.position;
            lookRange.transform.position = selected.Target.transform.position;
            attackRange.transform.Rotate(Vector3.forward);
            lookRange.transform.Rotate(Vector3.forward);
            turnedOf = false;

            if (!checkedRange)
            {
                float shootRangeNumber = GetShootRange();
                float lookRangeNumber = GetLookRange();
                attackRange.transform.localScale = new Vector3(shootRangeNumber / size, shootRangeNumber / size, 0);
                lookRange.transform.localScale = new Vector3(lookRangeNumber / size, lookRangeNumber / size, 0);
                checkedRange = true;
            }
        }//make this false when size gets updated
        else {
            if (!turnedOf) {
                turnedOf = true;
                lookRange.transform.localScale = Vector3.zero;
                attackRange.transform.localScale = Vector3.zero;
                checkedRange = false;
            }
        }
    }

    float GetShootRange()
    {
        if (selected.Target.name.Contains("Tower")) return selected.Target.gameObject.GetComponent<TurretBase>().atackRange;
        else if (selected.Target.name.Contains("Cat")) {
            return selected.Target.gameObject.GetComponent<UnitBase>().atackRange;
        }
        else if (selected.Target.name == "Base") return selected.Target.gameObject.GetComponent<TurretBase>().atackRange;
        else return 0;
    }

    float GetLookRange()
    {
        if (selected.Target.name.Contains("Cat")) {
            return selected.Target.GetComponent<UnitBase>().lookRange;
        } else return 0f;
    }
}
