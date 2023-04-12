using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;
    PlayerLevelUp playerExp;
    public PlayerSO _playerSO;

    private void Awake()
    {
        playerExp = FindObjectOfType<PlayerLevelUp>();
        speed = _playerSO.bulletSpeed;
    }

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
            playerExp.AddExp();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
