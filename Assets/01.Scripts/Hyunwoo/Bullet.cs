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
        way = player.position - transform.position;
        way = way.normalized;
    }
    void Update()
    {
        transform.Translate(way * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ASDASD");
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
