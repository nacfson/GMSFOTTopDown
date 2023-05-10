using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFarAttacker : EnemyParent
{
    public GameObject bulletPrefab;
    public LayerMask Player;
    protected override void Awake()
    {
        base.Awake();
        range = 5f; // 플레이어에게 다가가다가 멈춰서는 거리
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(StartAttack()); // 원거리 공격 코루틴
    }

    protected override void Update()
    {
        base.Update();
        float distance = Vector2.Distance(transform.position, player.position); // 플레이어와 원거리 적의 거리
        if(dying == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); // 플레이어에게 이동
        }
        if (distance <= range) // 범위안에 들어왔다면
        {
            inChase = true;
            speed = 0f;
        }
        else if (distance > range) // 범위밖이라면
        {
            inChase = false; 
            speed = 2f;
        }
        if (inChase == true) 
        {
            Chase();
        }
        
    }

    public void Chase() // 범위안에 들어온 경우 실행되는 함수
    {
        if (onAttack == false)
        {
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }

    IEnumerator StartAttack()
    {
        while (true)
        {
            if (dying == false || player != null)
            {
                float distance = Vector2.Distance(transform.position, player.position);
                if (distance <= 5f)
                {
                    SoundManager.Instance.SFXPlay(SFX);
                    GameObject obj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    obj.transform.SetParent(null);
                }
            }
            yield return new WaitForSeconds(attackDelay);
        }
    }
    public void Dead()
    {
        onAttack = false;
        Destroy(gameObject);
    }
    protected override IEnumerator Damaged()
    {
        return base.Damaged();
    }
}

