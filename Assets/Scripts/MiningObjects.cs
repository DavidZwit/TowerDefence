using UnityEngine;
using System.Collections;

public class MiningObjects : MonoBehaviour {
    [SerializeField] private int health = 10;
    [SerializeField] private int lifetime = 5;
    private Resources resourceScript;

    void Awake()
    {
        resourceScript = GameObject.Find("Handeler").GetComponent<Resources>();
    }

    void FixedUpdate()
    {
        if (Time.time % 1 == 0)
        {
            lifetime--;
            if (lifetime <= 0) Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        health-= resourceScript.MineStrength; 
        if (health <= 0)
        {
            if (gameObject.name.Contains("fish")) {
                resourceScript.Fish++;
            }
            else if (gameObject.name.Contains("yarn"))
            {
                resourceScript.Yarn++;
            }
            else if (gameObject.name.Contains("cardboard"))
            {
                resourceScript.Cardboard++;
            }
            else print("Error, this is a unknown resource");
            Destroy(gameObject);
        }
    }
}
