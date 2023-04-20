using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBig : EnemyParent
{
    public LayerMask Player;
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
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= enemySO.follow)
        {
            inChase = true;
        }
        else if (distance > enemySO.follow)
        {
            inChase = false;
        }
        if (inChase == true)
        {
            Chase();
        }
        if (distance <= 2.5f)
        {
            StartAttack();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (getKey == true)
            {
                enemySO.hp--;
                if (enemySO.hp <= 0)
                {
                    animator.SetTrigger("Dead");
                    getKey = false;
                    dying = true;
                }
            }
        }

    }
    private void FixedUpdate()
    {
        isAttack = Physics2D.OverlapCircle(transform.position, 4f, Player);
    }

    public void Chase()
    {
        if (onAttack == false && dying == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if (transform.position.x - player.position.x < 0)
            {
                sprite.flipX = false;
            }
            else if (transform.position.x - player.position.x >= 0)
            {
                sprite.flipX = true;
            }
        }

    }
    public void StartAttack()
    {
        animator.SetBool("Attack", true);
    }

    public void StopAttack() // 공격중 움직이지 않게 만들어주는 함수 : 공격 애니메이션 시작 시 실행됨
    {
        SoundManager.Instance.SFXPlay(SFX);
        onAttack = true;
        Invoke("ReturnRun", 2f);

    }
    public void ReturnRun()
    {
        animator.SetBool("Attack", false);
        onAttack = false;
    }
    public void Hit()
    {
        if (isAttack == true)
        {
            testplayercontroller.hp -= enemySO.attack;
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
        Gizmos.DrawWireSphere(transform.position, 4f);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

