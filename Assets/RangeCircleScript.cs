using UnityEngine;
using System.Collections;

public class RangeCircleScript : MonoBehaviour {
    float size = 200;
    bool checkedRange, turnedOf;
    Selected selected;
    GameObject lookRange;

    void Awake()
    {
        selected = GameObject.Find("Handeler").GetComponent<Selected>();
        lookRange = GameObject.Find("LookRangeCircle");
    }

    private void Update()
    {
        if (selected.Target)
        {
            transform.position = selected.Target.transform.position;
            lookRange.transform.position = transform.position;
            lookRange.transform.Rotate(Vector3.forward);
            transform.Rotate(Vector3.forward);
            turnedOf = false;

            if (!checkedRange)
            {
                float shootRange = GetShootRange();
                float lookRangeNumber = GetLookRange();
                transform.localScale = new Vector3(shootRange / size, shootRange / size, 0);
                lookRange.transform.localScale = new Vector3(lookRangeNumber / size, lookRangeNumber / size, 0);
                checkedRange = true;
            }
        }//make this false when size gets updated
        else {
            if (!turnedOf) {
                turnedOf = true;
                lookRange.transform.localScale = Vector3.zero;
                transform.localScale = Vector3.zero;
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
        } else return 0;
    }
}
