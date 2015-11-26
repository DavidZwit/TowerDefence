using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreateObject : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectList = new List<GameObject>();
    [SerializeField]
    private Button catButton, towerButton, boxButton;
    private GameObject parrent;
    private Resources resources;
    private Selected selected;
    private GridDrag gridDrag;
    private select Select;

    void Awake()
    {   
        parrent = GameObject.Find("Players");
        resources = GameObject.Find("Handeler").GetComponent<Resources>();
        selected = GameObject.Find("Handeler").GetComponent<Selected>();
        gridDrag = GameObject.Find("Handeler").GetComponent<GridDrag>();
        Select = GameObject.Find("Handeler").GetComponent<select>();
    }

    void FixedUpdate()
    {
        if (resources.Yarn >= 5) towerButton.interactable = true;
        else towerButton.interactable = false;
        if (resources.Fish > 5) catButton.interactable = true; else catButton.interactable = false;
        if (resources.Cardboard >= 5) towerButton.interactable = true; else boxButton.interactable = false;
    }

    public void ObjectCreateString(string objectName)
    {
        for (int i = 0; i < objectList.Count; i++)
        {
            if (objectList[i].name == objectName)
            {
                if (objectName == "Tower") resources.Yarn -= 5;
                else if (objectName == "Cat") resources.Fish -= 5;
                else if (objectName == "Box") resources.Cardboard -= 5;

                GameObject player = Instantiate(objectList[i], Vector3.zero, Quaternion.identity) as GameObject;
                player.transform.parent = parrent.transform;
                selected.Target = player;
                Select.Select(player);
                Select.Drag(player);
            }
        }
    }

    public void ObjectCreateInt(int objectNumber)
    {
        GameObject player = Instantiate(objectList[objectNumber], Vector3.zero, Quaternion.identity) as GameObject;
        player.transform.parent = parrent.transform;
    }
}