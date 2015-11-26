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
        fishText = GameObject.Find("Fish_Button_Text").GetComponent<Text>();
        yarnText = GameObject.Find("Yarn_Ball_Text").GetComponent<Text>();
        cardboardText = GameObject.Find("Cardboard_Button_Text").GetComponent<Text>();
    }

    void Start()
    {
        fishText.text = "" + fish;
        yarnText.text = "" + yarn;
        cardboardText.text = "" + cardboard;
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
            fish = value;
            fishText.text = "" + fish;
        }
    }

    public float Yarn
    {
        get { return yarn; }
        set {
            yarn = value;
            yarnText.text = "" + yarn;
        }
    }

    public float Cardboard
    {
        get { return cardboard; }
        set {
            cardboard = value;
            cardboardText.text = "" + cardboard;
        }
    }
    public int MineStrength
    {
        get { return mineStrength; }
        set { mineStrength = value; }
    }
}
