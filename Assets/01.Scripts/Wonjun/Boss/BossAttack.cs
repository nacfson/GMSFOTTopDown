using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float spawnRadius;
    [SerializeField]
    private float _bossHp;
    [SerializeField]
    private EnemySO bossSO;
    private Animator _anim;
    [SerializeField]
    private BossHpBar _bossHpBar =null;
    public float time;
    public float _damage = 0.04f;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    private void Start()
    {
       
        StartCoroutine(HpFill());
        InvokeRepeating("SpawnBoss", 5.5f, spawnInterval);
        _bossHp = bossSO.hp;
    }

    private IEnumerator HpFill()
    {
        time = 0;
        while (time < 2f)
        {
            _bossHpBar.HpGaugeNormal(time / 2f);
            time += Time.deltaTime;
            yield return null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _bossHp -= 10f;
            _bossHpBar.HpGaugeNormal((_bossHp / _bossHp)-_damage);
            _damage += 0.033f;
            Debug.Log(_bossHp);
        }
        else if (_bossHp <= 0)
        {
            _bossHpBar.HpGaugeNormal(0);
            _anim.SetTrigger("Dead");
        }
    }

    private void SpawnBoss()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[spawnPointIndex].position + Random.insideUnitSphere * spawnRadius;
        GameObject prefab = prefabs[spawnPointIndex];
        GameObject boss = PoolList.instance.Pop(prefab.name, spawnPosition);
        if (boss != null)
        {
            Invoke("PushBoss", 1.3f);
        }
    }

    private void PushBoss()
    {
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss != null)
        {
            PoolList.instance.Push(boss);
        }
    }
    private void BossDead()
    {
        Destroy(gameObject);
    }
}
