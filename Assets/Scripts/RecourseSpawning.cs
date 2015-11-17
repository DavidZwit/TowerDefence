using UnityEngine;
using System.Collections;

public class RecourseSpawning : MonoBehaviour {
    [SerializeField] private GameObject[] resources;
    [SerializeField] private float spawnRate = 50;
    private float nextSpawn;

    void OnEnable()
    {
        spawnRate -= 0.1f;
    }

    void Update()
    {
        SpawningObjects();
    }

    void SpawningObjects()
    {
        if (Time.time > nextSpawn)
        {
            GameObject randResource = resources[Random.Range(0, resources.Length)];

            Vector2 randPos;
            if (Random.Range(1, 3) == 1) {
                if (Random.Range(1, 3) == 1) randPos.x = Random.Range(-Screen.width * 2.5f, -Screen.width * 1.7f);
                else randPos.x = Random.Range(Screen.width * 1.7f, Screen.width * 2.5f);
                randPos.y = Random.Range(-Screen.height * 2.5f, Screen.height * 1.9f);
            } else {
                if (Random.Range(1, 3) == 1) randPos.y = Random.Range(-Screen.height * 1.7f, -Screen.height * 2.5f);
                else randPos.y = Random.Range(Screen.height * 1.7f, Screen.height * 1.9f);
                randPos.x = Random.Range(-Screen.width * 2.5f, Screen.width * 2.5f);
            }
            Instantiate(randResource, randPos, Quaternion.identity);

            nextSpawn = Time.time + spawnRate;
        }
    }
}
