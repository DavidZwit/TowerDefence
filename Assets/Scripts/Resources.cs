using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Resources : MonoBehaviour {

    [SerializeField] private float fish;
    [SerializeField] private float yarn;
    [SerializeField] private float cardboard;
    private Text fishText, cardboardText, yarnText;
    private int mineStrength = 1;

    void Awake()
    {
        fishText = GameObject.Find("FishScore").GetComponent<Text>();
        yarnText = GameObject.Find("YarnScore").GetComponent<Text>();
        cardboardText = GameObject.Find("CardboardScore").GetComponent<Text>();
    }

    public void EditResources(string objectName)
    {
        if (objectName == "Cat") Fish--;
        else if (objectName == "Tower") Yarn--;
        else if (objectName == "Wall") Cardboard--;
    }

    public float Fish
    {
        get { return fish; }
        set {
            fishText.text = "Fish: " + fish;
            fish = value; }
    }

    public float Yarn
    {
        get { return yarn; }
        set {
            yarnText.text = "Yarn: " + yarn;
            yarn = value; }
    }

    public float Cardboard
    {
        get { return cardboard; }
        set {
            cardboardText.text = "Cardboard: " + cardboard;
            cardboard = value; }
    }
    public int MineStrength
    {
        get { return mineStrength; }
        set { mineStrength = value; }
    }
}
