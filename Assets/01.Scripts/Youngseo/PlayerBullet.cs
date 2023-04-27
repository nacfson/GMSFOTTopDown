using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;
    PlayerLevelUp playerExp;
    [SerializeField] PlayerSO _playerSO;

    private void Awake()
    {
        playerExp = FindObjectOfType<PlayerLevelUp>();
        speed = _playerSO.bulletSpeed;
    }

    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
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
