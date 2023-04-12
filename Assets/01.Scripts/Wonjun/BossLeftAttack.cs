using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLeftAttack : MonoBehaviour
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
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, dir);
    }
    public void BossLeftpool()
    {
        if (hit.collider.IsTouchingLayers(a)){
            Debug.Log("1´Ù¾Æ¹ö·Ç!");
        }
        PoolList.instance.Push(boss.b);
        Debug.Log("¿ÞÂÊ");
    }
}
