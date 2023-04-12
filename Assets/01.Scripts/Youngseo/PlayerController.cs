using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera cam;
    float speed;
    public float xLimit;
    public float yLimit;
    public PlayerSO _playerSO;
    public GunRotate gunRotate;

    private void Awake()
    {
        cam = Camera.main;
        speed = _playerSO.speed;
        gunRotate = FindObjectOfType<GunRotate>();

    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(x, y).normalized * Time.deltaTime * speed;
        PlayerRotate();
    }

    private void LateUpdate()
    {
        float x = Mathf.Clamp(transform.position.x, -xLimit, xLimit);
        float y = Mathf.Clamp(transform.position.y, -yLimit, yLimit);
        transform.position = new Vector2(x, y);
    }

    private void PlayerRotate()
    {
        float x = cam.ScreenToWorldPoint(Input.mousePosition).x;

        if (x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            gunRotate.Flipreverse();
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            gunRotate.Flip();
        }
    }
}
