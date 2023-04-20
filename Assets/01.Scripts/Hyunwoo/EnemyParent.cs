using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyParent : MonoBehaviour
{
    [SerializeField]
    protected EnemySO enemySO;
    protected Transform player;
    
    protected Vector2 size;
    protected Vector2 playerPos;
    protected float hp;
    protected float speed;
    protected float range;
    protected float attackDelay = 1f;
    protected SpriteRenderer sprite;
    protected Animator animator;
    protected TestPlayerController testplayercontroller;
    [SerializeField]
    protected AudioSource SFX;

    protected bool onAttack = false;
    protected bool inChase = false;
    protected bool isAttack = true;
    protected bool getKey = true;
    protected bool dying = false;



    protected virtual void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        testplayercontroller = GameObject.Find("Player").GetComponent<TestPlayerController>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        SFX = GetComponent<AudioSource>();
    }
    protected virtual void Start()
    {
        speed = enemySO.speed;
        range = enemySO.follow;
        hp = enemySO.hp;
    }

    protected virtual void Update()
    {
        
    }
}
