using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventHandeler : MonoBehaviour {

    private GameObject begin, buildTime, inWave, tryAgain;
    private GameObject enemies, pauseMenu;

    public delegate void Action();
    public delegate void Stop();
    public static event Action StartBattle;
    public static event Stop StopBattle;
    private int timeInBuild = 60;
    private int timeInWave = 120;
    private int waveCount;
    private float timer;
    private Text timerText, waveCountText;
    public static bool pause;

    void Awake()
    {
        begin = GameObject.Find("Begin");
        buildTime = GameObject.Find("BuildTime");
        inWave = GameObject.Find("InWave");
        tryAgain = GameObject.Find("End");
        enemies = GameObject.Find("Enemies");
        timerText = GameObject.Find("Time_Text").GetComponent<Text>();
        waveCountText = GameObject.Find("Wave_Text").GetComponent<Text>();
        pauseMenu = GameObject.Find("PauseMenu");
    }

    void FixedUpdate()
    {
        timerText.text = "Time: " + timer;
        if (Time.time % 1 == 0 && timer > 0 && !pause) timer--;

        if (timer == 0) {
            if (inWave.active) {
                int enemyLenght = GameObject.FindGameObjectsWithTag("Enemy").Length;
                if (enemyLenght == 0) {
                    Build();
                }
            } else if (buildTime.active) {
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
        tryAgain.SetActive(false);
        pauseMenu.SetActive(false);
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
        waveCount++; waveCountText.text = "Wave " + waveCount;
        begin.SetActive(false);
        buildTime.SetActive(false);
        inWave.SetActive(true);
        timer = timeInWave;

        if (StartBattle != null)
            StartBattle();
    }

    public void EndGame()
    {
        begin.SetActive(false);
        buildTime.SetActive(false);
        inWave.SetActive(false);
        tryAgain.SetActive(true);
    }

    public void loadThisLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void pauseGame()
    {
        if (pause) {
            pauseMenu.SetActive(false);
        } else {
            pauseMenu.SetActive(true);
        }
        pause = !pause;
    }
}
