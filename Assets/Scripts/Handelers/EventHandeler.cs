using UnityEngine;
using System.Collections;

public class EventHandeler : MonoBehaviour {

    private GameObject begin;
    private GameObject buildTime;
    private GameObject inWave;

    void Awake()
    {
        begin = GameObject.Find("Begin");
        buildTime = GameObject.Find("BuildTime");
        inWave = GameObject.Find("InWave");   
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
    }

    public void Wave()
    {
        begin.SetActive(false);
        buildTime.SetActive(false);
        inWave.SetActive(true);
    }
}
