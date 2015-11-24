using UnityEngine;
using System.Collections;

public class RecourseSpawning : MonoBehaviour {
    [SerializeField] private GameObject[] resources;
    [SerializeField] private float spawnRate = 0.001f;
    private float nextSpawn;
    private Transform map;
    private Vector2 mapSize;

    void OnEnable()
    {
        spawnRate -= 0.1f;
    }

    void Start()
    {
        mapSize = new Vector2(map.localScale.x, map.localScale.y);
    }

    void Awake()
    {
        map = GameObject.Find("Map").transform;
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
                if (Random.Range(1, 3) == 1) randPos.x = Random.Range(-mapSize.x *1.5f, -mapSize.x * 1.7f);
                else randPos.x = Random.Range(mapSize.x * 1.7f, mapSize.x * 2.5f);
                randPos.y = Random.Range(-mapSize.y * 2.5f, mapSize.y * 1.9f);
            } else {
                if (Random.Range(1, 3) == 1) randPos.y = Random.Range(-mapSize.y *1.7f, -mapSize.y * 2.5f);
                else randPos.y = Random.Range(mapSize.y * 1.7f, mapSize.y * 1.9f);
                randPos.x = Random.Range(-mapSize.x * 2.5f, mapSize.x * 2.5f);
            }
            /*
            if (Random.Range(1, 3) == 1)
            {
                if (Random.Range(1, 3) == 1) randPos.x = Random.Range(-mapSize.x, -mapSize.x);
                else randPos.x = Random.Range(mapSize.x, mapSize.x);
                randPos.y = Random.Range(-mapSize.y, mapSize.y);
            }
            else
            {
                if (Random.Range(1, 3) == 1) randPos.y = Random.Range(-mapSize.y, -mapSize.y);
                else randPos.y = Random.Range(mapSize.y, mapSize.y);
                randPos.x = Random.Range(-mapSize.x, mapSize.x);
            }
             * */
            Instantiate(randResource, randPos, Quaternion.identity);

            nextSpawn = Time.time + spawnRate;
        }
    }
}
