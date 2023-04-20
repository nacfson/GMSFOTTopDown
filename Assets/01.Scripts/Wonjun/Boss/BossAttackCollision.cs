using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackCollision : MonoBehaviour
{
    [SerializeField]
    private LayerMask _layermask;
    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.BoxCast(transform.position, new Vector3(2, 3, 1), 0, Vector2.zero, _layermask);
    }

    public void AttackTrigger()
    {
        if (hit)
        {
            Debug.Log("하모예");
        }
        else
        {
            Debug.Log("안닿았어");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(2, 3, 1));
    }
}
