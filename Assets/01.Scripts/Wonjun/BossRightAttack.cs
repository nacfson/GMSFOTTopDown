using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BossRightAttack : MonoBehaviour
{
    Boss boss;
    public LayerMask a;
    RaycastHit2D hit;
    public Vector3 dir = new Vector3(4, 4, 0);
    private void Awake()
    {
        boss = FindObjectOfType<Boss>();
    }
    private void Update()
    {
        hit = Physics2D.BoxCast(transform.position, dir, 0, Vector2.down, a);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawCube(transform.position, dir);
    }
    public void BossRightpool()
    {
        if (hit.collider.IsTouchingLayers(a))
        {
            Debug.Log("다아버렷!");
        }
        PoolList.instance.Push(boss.a);
        Debug.Log("오른쪽");
    }
}
