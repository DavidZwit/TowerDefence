using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
    [SerializeField]
    private List<Transform> Spawners = new List<Transform>();
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject parrent;

    private int spawnRate = 100;

    void Update()
    {
        if (Random.Range(0, spawnRate) == 1)
        {
            Vector2 randomTrans = new Vector2(Spawners[Random.Range(0, Spawners.Count)].position.x, Spawners[Random.Range(0, Spawners.Count)].position.y);

            GameObject hostile = Instantiate(enemy, randomTrans, Quaternion.identity) as GameObject;
            hostile.transform.SetParent(transform);
        }
    }
}