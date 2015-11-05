using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
    [SerializeField]
    private List<Transform> Spawners = new List<Transform>();
    [SerializeField]
    private GameObject enemie;

    private int spawnRate = 500;

    void Update()
    {
        if (Random.Range(0, spawnRate) == 1)
        {
            Vector2 randomTrans = new Vector2(Spawners[Random.Range(0, Spawners.Count)].position.x, Spawners[Random.Range(0, Spawners.Count)].position.y);
            Instantiate(enemie, randomTrans, Quaternion.identity);
        }
    }
}
