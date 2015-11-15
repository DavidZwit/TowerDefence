using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitBase : Humanoid {
    [SerializeField] protected int moveSpeed = 50;
    [SerializeField] protected int lookRange = 500;
    [SerializeField] protected float lookSpeed = 3;
    protected float nextLook;
    protected Vector3 fallBackSpot;
    private int walkAngleHash = Animator.StringToHash("WalkAngle");

    protected void Start()
    {
        if (!isFriendly) fallBackSpot = GameObject.Find("Base").transform.position;
        SetRotationPos(fallBackSpot, "lookPos");
    }

    protected void WalkToTargets()
    {
        if (Time.time > nextLook)
        {
            targets = CheckTargets(lookRange);
            nextLook = Time.time + lookSpeed;
        }
        if (targets.Length > 0 && targets[0] != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, targets[0].transform.position, moveSpeed);
            SetRotationPos(targets[0].transform.position, "lookPos");
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, fallBackSpot, moveSpeed);
            SetRotationPos(fallBackSpot, "lookPos");
        }
    }

    void Update()
    {
        if (inBattle)
        {
            Atack();
            if (!attacking) WalkToTargets();
        }
    }

    protected override void StartBattle()
    {
            base.StartBattle();
            fallBackSpot = transform.position;
    }

    protected override void StopBattle()
    {
        base.StopBattle();
    }
}
