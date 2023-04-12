using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        gunRotate();
    }

    private void gunRotate()
    {
        float x = cam.ScreenToWorldPoint(Input.mousePosition).x;
        float y = cam.ScreenToWorldPoint(Input.mousePosition).y;
        float z = Mathf.Atan2(y - transform.position.y, x - transform.position.x) * Mathf.Rad2Deg;
        if (transform.localScale.z < 0) transform.localScale = transform.localScale * -1;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, z);
    }

    public void Flipreverse()
    {
        transform.localScale = new Vector3(-1, -1, 1);
    }
    public void Flip()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}
