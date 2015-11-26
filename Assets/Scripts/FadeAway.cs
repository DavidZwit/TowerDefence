using UnityEngine;
using System.Collections;

public class FadeAway : MonoBehaviour {

    private SpriteRenderer sRenderer;
    private float alpha = 1;

    void Awake()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        sRenderer.color = new Color(1f, 1f, 1f, 1f);
        alpha = 1;
    }

    void FixedUpdate()
    {
        if (alpha > 0)
        {
            alpha -= 0.01f;

            sRenderer.color = new Color(1f, 1f, 1f, alpha);
        }
    }
}
