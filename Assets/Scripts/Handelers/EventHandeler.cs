using UnityEngine;
using System.Collections;

public class EventHandeler : MonoBehaviour {

    private GameObject begin;
    private GameObject buildTime;
    private GameObject inWave;
    private GameObject enemies;

    public delegate void Action();
    public delegate void Stop();
    public static event Action StartBattle;
    public static event Stop StopBattle;

    void Awake()
    {
        begin = GameObject.Find("Begin");
        buildTime = GameObject.Find("BuildTime");
        inWave = GameObject.Find("InWave");
        enemies = GameObject.Find("Enemies");
    }

    void Start()
    {
        Begin();
    }

    public void Begin()
    {
        begin.SetActive(true);
        buildTime.SetActive(false);
        inWave.SetActive(false);
    }

    public void Build()
    {
        begin.SetActive(false);
        buildTime.SetActive(true);
        inWave.SetActive(false);

        if (StopBattle != null)
            StopBattle();

        for (int i = enemies.transform.childCount - 1; i >= 0; i--)
        {
            Transform deleteChild = enemies.transform.GetChild(i);
            Destroy(deleteChild.transform.gameObject);
        }
    }

    public void Wave()
    {
        begin.SetActive(false);
        buildTime.SetActive(false);
        inWave.SetActive(true);

        if (StartBattle != null)
            StartBattle();
    }
}
