using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public EnemySO enemySO;
    public Transform player;
    public float speed = 3f;
    public Vector2 way;
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

    public float Damage(float hp)
    {
        hp -= enemySO.attack;
        return hp;
    }
}
