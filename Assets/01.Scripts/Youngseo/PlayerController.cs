using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera cam;
    float speed = 5f;
    public float xLimit;
    public float yLimit;

    private void Awake()
    {
        cam = Camera.main;
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
        float y = cam.ScreenToWorldPoint(Input.mousePosition).y;
        float z = Mathf.Atan2(y - transform.position.y, x - transform.position.x) * Mathf.Rad2Deg;
        if (transform.localScale.z < 0) transform.localScale = transform.localScale * -1;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, z);
    }
}
