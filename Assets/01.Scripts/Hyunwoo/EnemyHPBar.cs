using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPBar : MonoBehaviour
{
    Transform _BarTrm;
    public EnemySO enemySO;
    //public PlayerSO playerSO;
    float fullHp = 1f;
    float damage;

    private void Awake()
    {
        _BarTrm = transform.Find("HpBar");
    }

    private void Start()
    {
        damage = 100 / enemySO.hp;
        damage /= 100; // 데미지 1당 닳아야할 스케일 값
    }

    public void Damage()
    {
        fullHp -= damage;// * playerSO.damage;
        _BarTrm.localScale = new Vector3(fullHp, 1, 1);
    }
}
