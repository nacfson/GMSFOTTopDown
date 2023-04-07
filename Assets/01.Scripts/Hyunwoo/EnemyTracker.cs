using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : EnemyParent
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        isAttack = Physics2D.OverlapCircle(transform.position, 1f, Player);
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
            testplayercontroller.Damage();
        }
    }
    public void Dead()
    {
        onAttack = false;
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
}

