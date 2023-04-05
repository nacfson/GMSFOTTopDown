using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{

    public Transform player;
    public float speed = 5f;
    public float range = 5f;
    public bool inChase = false;

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);;
        if (distance <= range)
        {
            inChase = true;
        }
        if(inChase == true)
        {
            Chase();
        }
    }

    public void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}

