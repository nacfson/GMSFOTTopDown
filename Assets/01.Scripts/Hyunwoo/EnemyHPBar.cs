using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPBar : MonoBehaviour
{
    Transform _BarTrm;
    public EnemySO enemySO;
    float fullHp = 1f;
    float hp;

    private void Awake()
    {
        _BarTrm = transform.Find("HpBar");
    }

    private void Start()
    {
        hp = 100 / enemySO.hp;
        hp /= 100; // 1�� ��ƾ��� ������ ��
        Debug.Log($"{transform.parent.name}�� �������� : {hp}");
        Debug.Log($"{transform.parent.name}�� �� hp �� : {fullHp}");
    }

    public void Damage()
    {
        fullHp -= hp;
        _BarTrm.localScale = new Vector3(fullHp, 0, 0);
        Debug.Log($"{transform.parent.name}�� �������� : {hp}");
        Debug.Log($"{transform.parent.name}�� �� hp �� : {fullHp}");
    }
}
