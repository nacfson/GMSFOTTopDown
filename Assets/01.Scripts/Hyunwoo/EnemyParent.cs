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

    protected bool onAttack = false; // ���� ������ �Ǵ��ϴ� ����
    protected bool inChase = false; // ���� ������ ���Դ��� �Ǵ��ϴ� ����
    protected bool isAttack = true; // ���� ������ ���Դ��� �Ǵ��ϴ� ����
    protected bool getKey = true; // ������ �ӽ� �ڵ忡 ���� ����
    protected bool dying = false; // �״µ��� ������ �� ���� �ϴ� ����



    protected virtual void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        testplayercontroller = GameObject.FindWithTag("Player").GetComponent<TestPlayerController>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
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
        if (Input.GetKeyDown(KeyCode.Space)) // �ӽ� hp��� �ڵ�
        {
            if (getKey == true)
            {
                hp--;
                StartCoroutine(Damaged());
                if (hp <= 0)
                {
                    animator.SetTrigger("Dead");
                    getKey = false;
                    dying = true;
                }
            }
        }
    }
    protected virtual IEnumerator Damaged()
    {
        ParticleManager.Instance.SFXPlay(enemySO.bloodParticle, transform.position); //�� �������� �÷��̾��� �Ѿ��� ���� ���������� �ٲ� ����
        transform.GetChild(0).gameObject.GetComponent<EnemyHPBar>().Damage();
        sprite.color = new Color(255, 0, 0, 255);
        yield return new WaitForSeconds(0.3f);
        sprite.color = new Color(255, 255, 255, 255);
        yield break;
    }

}
