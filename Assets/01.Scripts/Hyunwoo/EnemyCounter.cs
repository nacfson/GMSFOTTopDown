using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField]
    private bool close;

    private void Start()
    {
        gameObject.SetActive(close);
    }

    void Update()
    {
        if(transform.childCount < 0 && gameObject.CompareTag("Close"))
        {
            gameObject.SetActive(!close);
        }
        else if (transform.childCount <= 0)
        {
            gameObject.SetActive(!close);
        }
    }
}
