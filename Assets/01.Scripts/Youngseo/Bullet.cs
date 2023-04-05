using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
        Collider2D Player = Physics2D.OverlapCircle(transform.position, 20f, 1 << 3);
        if (Player == null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }
}
