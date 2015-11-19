using UnityEngine;
using System.Collections;

public class DestroyComponent : MonoBehaviour {

	public void Destroy(string name)
    {
        Destroy(GetComponent(name));
    }
}
