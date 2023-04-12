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
        range = 4.5f;
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(StartAttack());
    }

    protected override void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if (distance <= range)
        {
            inChase = true;
            speed = 0f;
        }
        else if (distance > range)
        {
            inChase = false; 
            speed = 2f;
        }
        if (inChase == true)
        {
            Chase();
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
                }
            }
        }
    }

    public void Chase()
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
        Gizmos.DrawWireSphere(transform.position, 3.5f);
    }

    IEnumerator StartAttack()
    {
        while (true)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance <= 3.5f)
            {
                GameObject obj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                obj.transform.SetParent(null);
            }
            yield return new WaitForSeconds(attackDelay);
        }
    }
}

