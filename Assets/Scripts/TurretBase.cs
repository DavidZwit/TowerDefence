using UnityEngine;
using System.Collections;

public class TurretBase : Humanoid {

    protected void Start()
    {
        power = 2;
        health = 50;
        atackSpeed = 3;
        maxTargets = 3;
        atackDamage = 10;
        atackRange = 1000;
        damagePosOffset = new Vector3(0, 300, 0);
    }
    
    void FixedUpdate()
    {
        if (inBattle && !takenOver && !EventHandeler.pause) Atack();
    }

    protected override void StartBattle()
    {
        base.StartBattle();
    }

    protected override void StopBattle()
    {
        base.StopBattle();
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = bullets.Length - 1; i >= 0; i--)
        {
            Destroy(bullets[i].gameObject);
        }
    }
}
