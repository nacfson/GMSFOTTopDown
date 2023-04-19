using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    float speed;
    [SerializeField] float xLimit;
    [SerializeField] float yLimit;
    [SerializeField] PlayerSO _playerSO;
    GunRotate gunRotate;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        cam = Camera.main;
        speed = _playerSO.speed;
        gunRotate = FindObjectOfType<GunRotate>();

    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(x, y).normalized * Time.deltaTime * speed;
        if (x != 0 || y != 0) animator.SetBool("Walk", true);
        else animator.SetBool("Walk", false);
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
