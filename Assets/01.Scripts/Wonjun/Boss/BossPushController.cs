using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPushController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 4f;
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
        transform.Translate(Vector2.left * Time.deltaTime * _moveSpeed);
        hit = Physics2D.BoxCast(transform.position, new Vector3(2, 3, 1), 0, Vector2.zero, _layermask);

        if (hit)
        {
            Debug.Log("하모예");
        }
        else
        {
            Debug.Log("안닿았어");
        }
    }

    public void PushObject()
    {
        PoolList.instance.Push(gameObject);
    }
}
