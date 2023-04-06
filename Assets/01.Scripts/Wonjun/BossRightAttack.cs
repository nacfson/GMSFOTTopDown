using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRightAttack : MonoBehaviour
{
    Boss boss;
    private void Awake()
    {
        boss = FindObjectOfType<Boss>();
    }
    public void BossRightpool()
    {
        PoolList.instance.Push(boss.a);
        Debug.Log("¿À¸¥ÂÊ");
    }
}
