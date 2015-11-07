using UnityEngine;
using System.Collections;

public class GroundUnit : FriendlyBase {

    protected override void Start()
    {
        base.Start();
        health = 10;
    }

    void FixedUpdate()
    {
        if (inBattle)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 10);
            if (hitTarget && damageTarget != null) damageTarget.SendMessage("ApplyDamage", 2);
        }
    }

    protected override void StartBattle()
    {
        base.StartBattle();
    }

    protected override void StopWave()
    {
        base.StopWave();
    }
}
