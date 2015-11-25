using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateObject : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectList = new List<GameObject>();
    private GameObject parrent;
    private Resources resources;
    private Selected selected;
    private GridDrag gridDrag;

    void Awake()
    {   
        parrent = GameObject.Find("Players");
        resources = GameObject.Find("Handeler").GetComponent<Resources>();
        selected = GameObject.Find("Handeler").GetComponent<Selected>();
        gridDrag = GameObject.Find("Handeler").GetComponent<GridDrag>();
    }

    public void ObjectCreateString(string objectName)
    {
        for (int i = 0; i < objectList.Count; i++)
        {
            if (objectList[i].name == objectName)
            { 
                GameObject player = Instantiate(objectList[i], Vector3.zero, Quaternion.identity) as GameObject;
                player.transform.parent = parrent.transform;
                selected.Target = player;
                gridDrag.MoveObject = player;
            }
        }
    }

    public void ObjectCreateInt(int objectNumber)
    {
        GameObject player = Instantiate(objectList[objectNumber], Vector3.zero, Quaternion.identity) as GameObject;
        player.transform.parent = parrent.transform;
    }
}