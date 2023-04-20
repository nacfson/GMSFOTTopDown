using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPushController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * _moveSpeed);
    }

    public void PushObject()
    {
        PoolList.instance.Push(gameObject);
    }
}
