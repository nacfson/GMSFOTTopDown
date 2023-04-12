using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private float _bossHp = 500f;
    [SerializeField]
    public GameObject a;
    [SerializeField]
    public GameObject b;

    [SerializeField]
    private string rBossHand;
    [SerializeField]
    private string lBossHand;
    [SerializeField]
    private Transform _rtrm;
    [SerializeField]
    private Transform _lTrm;
    public GameObject _rhandAttack;
    public GameObject _lhandAttack;
    public float attackcool = 1f;
    int changeAttack = 0;

    private void Awake()
    {
        _rtrm = GameObject.Find("RAttackPos").transform;
        _lTrm = GameObject.Find("LAttackPos").transform;
    }

    private void Start()
    {
        StartCoroutine(HandAttack());

    }
    private void Update()
    {
    }

    IEnumerator HandAttack()
    {
        while (true)
        {
            if (changeAttack == 0)
            {
                b = PoolList.instance.Pop(lBossHand, _lTrm.position);
                changeAttack++;
                yield return new WaitForSeconds(attackcool);
                if (changeAttack > 0)
                {
                    a = PoolList.instance.Pop(rBossHand, _rtrm.position);
                    changeAttack = 0;
                    yield return new WaitForSeconds(attackcool);
                }
            }
        }
            
    }
}
