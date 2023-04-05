using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public Vector2 PlayerPos;

    void Update()
    {
        PlayerPos = transform.position;
    }
}
