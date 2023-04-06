using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLeftAttack : MonoBehaviour
{
    Boss boss;
    private void Awake()
    {
        boss = FindObjectOfType<Boss>();
    }
    public void BossLeftpool()
    {
        PoolList.instance.Push(boss.b);
        Debug.Log("¿ÞÂÊ");
    }
}
