using UnityEngine;
using System.Collections;

public class FriendlyBase : MonoBehaviour {
    protected bool inBattle;

    public virtual void StartBattle()
    {
        inBattle = true;
        GetComponent<select>().EditMode = false;
    }

    public virtual void StopWave()
    {
        inBattle = false;
        GetComponent<select>().EditMode = true;
    }

    void OnEnable()
    {
        ActivateBattle.StartBattle += StartBattle;
        ActivateBattle.StopBattle += StopWave;
    }

    void OnDiable()
    {
        ActivateBattle.StartBattle -= StartBattle;
        ActivateBattle.StopBattle -= StopWave;
    }
}
