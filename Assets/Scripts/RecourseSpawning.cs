using UnityEngine;
using System.Collections;

public class RecourseSpawning : MonoBehaviour {
    [SerializeField] private GameObject[] resources;
    [SerializeField] private float spawnRate = 0.001f;
    private int edgeOffset = 0; 
    private Vector2 middleOffset = new Vector2(1000, 500);
    private float nextSpawn;
    private Transform map;
    private Vector2 mapSize;

    void OnEnable()
    {
        spawnRate -= 0.1f;
    }
    
    void Awake()
    {
        map = GameObject.Find("Map").transform;
    }

    void Start()
    {
        mapSize = new Vector2(map.localScale.x, map.localScale.y) / 2;
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
                if (Random.Range(1, 3) == 1) randPos.x = Random.Range(-mapSize.x + edgeOffset, -middleOffset.x);
                else randPos.x = Random.Range(mapSize.x - edgeOffset, middleOffset.x);
                randPos.y = Random.Range(-mapSize.y + edgeOffset, mapSize.y - edgeOffset);
            } else {
                if (Random.Range(1, 3) == 1) randPos.y = Random.Range(-mapSize.y + edgeOffset, -middleOffset.y);
                else randPos.y = Random.Range(mapSize.y - edgeOffset, middleOffset.y);
                randPos.x = Random.Range(-mapSize.x + edgeOffset, mapSize.x - edgeOffset);
            }

            Instantiate(randResource, randPos, Quaternion.identity);

            nextSpawn = Time.time + spawnRate;
        }
    }
}
