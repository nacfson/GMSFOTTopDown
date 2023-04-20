using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public EnemySO enemySO;
    public Transform player;
    public float speed = 3f;
    public Vector2 way;
    public bool inChase = false;
    public bool isAttack = true;
    public bool getKey = true;
    TestPlayerController testplayercontroller;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
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
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            testplayercontroller.hp -= enemySO.attack;
            testplayercontroller.Damage();
        }
    }
}
