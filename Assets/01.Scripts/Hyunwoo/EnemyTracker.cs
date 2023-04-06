using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{

    [SerializeField]
    private EnemySO enemySO;
    public Transform player;
    public LayerMask Player;
    public Vector2 size;
    public Vector2 playerPos;
    public float speed;
    public float range;
    public float attackDelay = 1f;
    public bool inChase = false;
    public bool onAttack = false;
    public bool isAttack = true;
    SpriteRenderer sprite;
    Animator animator;


    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        speed = enemySO.speed;
        range = enemySO.follow;
    }

    void Update()
    {
        isAttack = Physics2D.OverlapCircle(transform.position, 1f);
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= enemySO.follow)
        {
            inChase = true;
        }
        else if (distance > enemySO.follow)
        {
            animator.SetBool("Run", false);
            inChase = false;
        }
        if(inChase == true)
        {
            Chase();
        }
        if (distance <= 1.5f)
        {
            StartAttack();
        }
    }

    public void Chase()
    {
        

        if (onAttack == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if(transform.position.x - player.position.x < 0)
            {
                sprite.flipX = false;
                animator.SetBool("Run", true);
            }
            else if(transform.position.x - player.position.x >= 0)
            {
                sprite.flipX = true;
                animator.SetBool("Run", true);
            }
        }
        
    }
    public void StartAttack()
    {
        animator.SetBool("Attack", true);
        
    }
    
    public void StopAttack()
    {
        onAttack = true;
        Invoke("ReturnRun", 0.8f);
        
    }
    public void ReturnRun()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Attack", false);
        onAttack = false;
    }
    public void Hit()
    {
        if (isAttack == true)
        {
            Debug.Log("°ø°ÝÁß");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
}

