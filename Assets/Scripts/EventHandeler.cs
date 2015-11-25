using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventHandeler : MonoBehaviour {

    private GameObject begin;
    private GameObject buildTime;
    private GameObject inWave;
    private GameObject enemies;

    public delegate void Action();
    public delegate void Stop();
    public static event Action StartBattle;
    public static event Stop StopBattle;
    private int timeInBuild = 60;
    private int timeInWave = 120;
    public float timer;
    public Text timerText;
    public static bool pause;

    void Awake()
    {
        begin = GameObject.Find("Begin");
        buildTime = GameObject.Find("BuildTime");
        inWave = GameObject.Find("InWave");
        enemies = GameObject.Find("Enemies");
    }

    void FixedUpdate()
    {
        timerText.text = "Time: " + timer;
        if (Time.time % 1 == 0 && timer > 0) timer--;

        if (timer == 0) {
            if (inWave.active) {
                int enemyLenght = GameObject.FindGameObjectsWithTag("Enemy").Length;
                if (enemyLenght == 0) {
                    Build();
                }
            }
            else if (buildTime.active) {
                Wave();
            }
        } 
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
        timer = timeInBuild;

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
        timer = timeInWave;

        if (StartBattle != null)
            StartBattle();
    }

    public static void EndGame()
    {
        Application.LoadLevel("EndScene");
    }
}
