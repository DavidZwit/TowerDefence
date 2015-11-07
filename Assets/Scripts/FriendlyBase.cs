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
        EventHandeler.StartBattle += StartBattle;
        EventHandeler.StopBattle += StopWave;
    }

    void OnDiable()
    {
        EventHandeler.StartBattle -= StartBattle;
        EventHandeler.StopBattle -= StopWave;
    }
}
