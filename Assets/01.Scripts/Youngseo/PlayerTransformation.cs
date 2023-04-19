using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransformation : MonoBehaviour
{
    public bool Form = false;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Transformation();
        }
    }
    private void Transformation()
    {
        if (!Form)
        {
            spriteRenderer.color = Color.red;
            Form = true;
        }
        else
        {
            spriteRenderer.color = Color.white;
            Form = false;
        }
    }
}
