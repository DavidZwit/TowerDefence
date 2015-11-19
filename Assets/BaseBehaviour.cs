using UnityEngine;
using System.Collections;

public class BaseBehaviour : TurretBase {

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public float AttackSpeed
    {
        get { return atackSpeed; }
        set { atackSpeed = value; }
    }

    public int AttackRange
    {
        get { return atackRange; }
        set { atackRange = value;}
    }
}
