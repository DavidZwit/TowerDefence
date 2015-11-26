using UnityEngine;
using System.Collections;

public class Selected : MonoBehaviour
{
    [SerializeField] private GameObject target;

    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }
}
