using UnityEngine;
using System.Collections;

public class FriendlyBase : CharactersBase {
    protected int health;

    protected virtual void Start()
    {
        targetTag = "Enemy";
    }

    protected virtual void StartBattle()
    {
        inBattle = true;
        GetComponent<select>().EditMode = false;
        fallBackSpot = transform.position;
        target = fallBackSpot;
    }

    protected virtual void StopWave()
    {
        inBattle = false;
        GetComponent<select>().EditMode = true;
        transform.position = fallBackSpot;
    }

    void OnEnable()
    {
        EventHandeler.StartBattle += StartBattle;
        EventHandeler.StopBattle += StopWave;
    }

    void OnDiable()
    {
        EventHandeler.StartBattle -= StartBattle;
        EventHandeler.StopBattle -= StopWave;
    }

    void OnDestroy()
    {
        EventHandeler.StartBattle -= StartBattle;
        EventHandeler.StopBattle -= StopWave;
    }

    void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }

    public int Health
    {
        get { return health; }
        set { health = value;
        if (health <= 0) Destroy(gameObject);
        }
    }
}
