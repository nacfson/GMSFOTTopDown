using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{

    [SerializeField]
    private EnemySO enemySO;
    public Transform player;
    public float speed;
    public float range = 5f;
    public float rotate;
    public bool inChase = false;
    SpriteRenderer sprite;


    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {


        speed = enemySO.speed;
    }

    void Update()
    {
        enemySO.follow = Vector2.Distance(transform.position, player.position);;
        if (enemySO.follow <= range)
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
        if(transform.position.x - player.position.x < 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }
}

