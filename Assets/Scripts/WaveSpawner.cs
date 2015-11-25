using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    private float waveValue = 10f;
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private Transform[] spawners;
    private bool inBattle;
    private float waveTime = 120f;
    private float spawnTimes;

    void Awake()
    {
        EventHandeler.StartBattle += StartWave;
        EventHandeler.StopBattle += StopWave;
    }

    void FixedUpdate()
    {
        if (inBattle && Time.time % spawnTimes == 0) {
            Vector2 randSpawener = spawners[Random.Range(0, spawners.Length)].position;
            GameObject randEnemie = enemies[Random.Range(0, enemies.Length)];
            GameObject spawnedEnemy = Instantiate(randEnemie, randSpawener, Quaternion.identity) as GameObject;

            spawnedEnemy.transform.SetParent(GameObject.Find("Enemies").transform);
        }
    }

    void StartWave()
    {
        waveValue += 5;
        spawnTimes = waveTime / waveValue;
        inBattle = true;
    }

    void StopWave()
    {
        inBattle = false;
    }

    void OnDestroy()
    {
        EventHandeler.StartBattle -= StartWave;
        EventHandeler.StopBattle -= StopWave;
    }
}