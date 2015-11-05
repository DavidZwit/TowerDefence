using UnityEngine;
using System.Collections;

public class ActivateBattle : MonoBehaviour {
    public delegate void Action();
    public delegate void Stop();
    public static event Action StartBattle;
    public static event Stop StopBattle;
    private GameObject enemies;

    void Awake()
    {
        enemies = GameObject.Find("Enemies");
    }

	public void StartFighting()
    {
        if (StartBattle != null)
            StartBattle();
    }

    public void StopFighting()
    {
        if (StopBattle != null)
            StopBattle();

        for (int i = enemies.transform.childCount - 1; i >= 0; i--)
        {
            Transform deleteChild = enemies.transform.GetChild(i);
            Destroy(deleteChild.transform.gameObject);
        }
    }
}
