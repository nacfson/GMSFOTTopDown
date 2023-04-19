using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    [SerializeField]
    UnityEvent UnityEvent = null;

    public void a()
    {
        Debug.Log("123");
    }
}
