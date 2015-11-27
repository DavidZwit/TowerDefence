﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitBase : Humanoid {
    [SerializeField] public int moveSpeed = 50;
    [SerializeField] public int lookRange = 500;
    [SerializeField] protected float lookSpeed = 3;
    protected float nextLook;
    protected Vector3 fallBackSpot;
    protected Rigidbody2D rb;

    protected void Start()
    {
        if (!isFriendly) fallBackSpot = GameObject.Find("Base").transform.position;
        rb = GetComponent<Rigidbody2D>();
        SetRotationPos(fallBackSpot, "lookPos");

        health = 50; maxTargets = 2; atackDamage = 5; atackSpeed = 2;
    }

    protected void WalkToTargets()
    {
        if (Time.time > nextLook)
        {
            targets = CheckTargets(lookRange);
            nextLook = Time.time + lookSpeed;
        }
        if (targets != null && targets.Length > 0) {
            rb.transform.position = Vector2.MoveTowards(transform.position, targets[0].transform.position, moveSpeed);
            SetRotationPos(targets[0].transform.position, "lookPos");
        } else {
            rb.transform.position = Vector2.MoveTowards(transform.position, fallBackSpot, moveSpeed);
            SetRotationPos(fallBackSpot, "lookPos");
        }
    }

    void FixedUpdate()
    {
        if (inBattle && !takenOver && !EventHandeler.pause) {
            if (isFriendly && !takenOver) {
                Atack();
                if (!attacking) WalkToTargets();
            } else {
                Atack();
                if (!attacking) WalkToTargets();    
            }
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
