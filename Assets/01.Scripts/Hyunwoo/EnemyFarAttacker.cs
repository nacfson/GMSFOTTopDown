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
        range = 5f; // �÷��̾�� �ٰ����ٰ� ���缭�� �Ÿ�
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(StartAttack()); // ���Ÿ� ���� �ڷ�ƾ
    }

    protected override void Update()
    {
        base.Update();
        float distance = Vector2.Distance(transform.position, player.position); // �÷��̾�� ���Ÿ� ���� �Ÿ�
        if(dying == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); // �÷��̾�� �̵�
        }
        if (distance <= range) // �����ȿ� ���Դٸ�
        {
            inChase = true;
            speed = 0f;
        }
        else if (distance > range) // �������̶��
        {
            inChase = false; 
            speed = 2f;
        }
        if (inChase == true) 
        {
            Chase();
        }
        
    }

    public void Chase() // �����ȿ� ���� ��� ����Ǵ� �Լ�
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

