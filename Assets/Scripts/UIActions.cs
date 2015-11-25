using UnityEngine;
using System.Collections;

public class UIActions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeScene(int sceneNumber)
    {
        Application.LoadLevel(sceneNumber);
    }

    public void PauseGame()
    {
        Time.fixedDeltaTime = 0;
    }
}
