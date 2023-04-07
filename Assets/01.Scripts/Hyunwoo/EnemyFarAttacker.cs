using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFarAttacker : EnemyParent
{
    public GameObject bulletPrefab;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(StartAttack());
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (getKey == true)
            {
                enemySO.hp--;
                if (enemySO.hp <= 0)
                {
                    getKey = false;
                    Destroy(gameObject);
                }
            }
        }
    }

    public void Chase()
    {
        if (onAttack == false)
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 6f);
    }

    IEnumerator StartAttack()
    {
        while (true)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance <= 6f)
            {
                GameObject obj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                obj.transform.SetParent(null);
            }
            yield return new WaitForSeconds(attackDelay);
        }
    }
}

