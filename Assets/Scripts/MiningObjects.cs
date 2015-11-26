using UnityEngine;
using System.Collections;

public class MiningObjects : MonoBehaviour {
    [SerializeField] private int health = 15;
    private Resources resourceScript;

    void Awake()
    {
        resourceScript = GameObject.Find("Handeler").GetComponent<Resources>();
    }

    void FixedUpdate()
    {
        if (Time.time % 1 == 0)
        {
            health--;
            if (health <= 0) Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnMouseDown()
    {
        health -= 5;

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
    }
}
