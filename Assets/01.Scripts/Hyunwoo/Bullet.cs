using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public Vector2 way;
    TestPlayerController testplayercontroller;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        testplayercontroller = GameObject.Find("Player").GetComponent<TestPlayerController>();
    }
    void Start()
    {
        transform.SetParent(null);
        way = player.position;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position , new Vector2(way.x,way.y) , speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            testplayercontroller.hp--;
        }
    }
}
