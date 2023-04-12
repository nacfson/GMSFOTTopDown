using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransformation : MonoBehaviour
{
    public bool Form = false;

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
            GetComponent<SpriteRenderer>().color = Color.red;
            Form = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            Form = false;
        }
    }
}
