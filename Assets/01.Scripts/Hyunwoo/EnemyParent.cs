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

    protected bool onAttack = false; // 공격 중인지 판단하는 변수
    protected bool inChase = false; // 감지 범위에 들어왔는지 판단하는 변수
    protected bool isAttack = true; // 공격 범위에 들어왔는지 판단하는 변수
    protected bool getKey = true; // 데미지 임시 코드에 들어가는 변수
    protected bool dying = false; // 죽는동안 움직일 수 없게 하는 변수



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
        if (Input.GetKeyDown(KeyCode.Space)) // 임시 hp깎기 코드
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
        ParticleManager.Instance.SFXPlay(enemySO.bloodParticle, transform.position); //이 포지션은 플레이어의 총알을 맞을 포지션으로 바꿀 예정
        transform.GetChild(0).gameObject.GetComponent<EnemyHPBar>().Damage();
        sprite.color = new Color(255, 0, 0, 255);
        yield return new WaitForSeconds(0.3f);
        sprite.color = new Color(255, 255, 255, 255);
        yield break;
    }

}
