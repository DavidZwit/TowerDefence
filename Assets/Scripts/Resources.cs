using UnityEngine;
using System.Collections;

public class Resources : MonoBehaviour {

    [SerializeField] private float fish;
    [SerializeField] private float yarn;
    [SerializeField] private float cardboard;
    private int mineStrength = 1;

    public void EditResources(string objectName)
    {
        if (objectName == "Cat") Fish--;
        else if (objectName == "Tower") Yarn--;
        else if (objectName == "Wall") Cardboard--;
    }

    public float Fish
    {
        get { return fish; }
        set { fish = value; }
    }

    public float Yarn
    {
        get { return yarn; }
        set { yarn = value; }
    }

    public float Cardboard
    {
        get { return cardboard; }
        set { cardboard = value; }
    }
    public int MineStrength
    {
        get { return mineStrength; }
        set { mineStrength = value; }
    }
}
