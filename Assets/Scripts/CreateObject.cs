using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateObject : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectList = new List<GameObject>();

    public void ObjectCreate()
    {
        Instantiate(objectList[Random.Range(0, objectList.Count)], Vector2.zero, Quaternion.identity);
    }
}