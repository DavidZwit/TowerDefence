using UnityEngine;
using System.Collections;

public class CharactersBase : MonoBehaviour {
    private bool atTarget = false;

    protected Vector3 target;
    protected bool hitTarget, inBattle;
    protected Vector3 fallBackSpot;
    protected int lookRange = 500;
    protected string targetTag;
    protected GameObject damageTarget;

    protected virtual void Update()
    {
        if (inBattle)
        {        //Handles the moving to target and atacking
            if (!atTarget)
            {
                target = findClosestTargetInRange();
                hitTarget = false;
            }
            else if (damageTarget != null)
            {
                hitTarget = true;
            } else atTarget = false;
        }
    }

    //Finds the targets that ar in range
    Vector3 findClosestTargetInRange()
    {
        GameObject[] targetLocations = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject gm in targetLocations)
        {
            if (Vector3.Distance(transform.position, gm.transform.position) < lookRange)
            {
                return gm.transform.position;
            }
        }
        return fallBackSpot;
    }

    //Checks if is arived at target
    void  OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == targetTag)
        {
            atTarget = true;
            damageTarget = coll.gameObject;
        }
    }
}
