using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHandAttack : MonoBehaviour
{
    Boss boss;

    private void Awake()
    {
        boss = FindObjectOfType<Boss>();
    }

    public void BossHandpool()
    {
        PoolList.instance.Push(boss.a);
    }
}
