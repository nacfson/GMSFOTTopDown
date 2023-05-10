using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunRotate : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        GunRotate();
    }

    private void GunRotate()
    {
        float x = cam.ScreenToWorldPoint(Input.mousePosition).x;
        float y = cam.ScreenToWorldPoint(Input.mousePosition).y;
        float z = Mathf.Atan2(y - transform.position.y, x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, z);
    }

    public void Flip(float flip)
    {
        if(flip == -1) transform.localScale = new Vector3(-1, -1, 1);
        else transform.localScale = new Vector3(1, 1, 1);
    }
}
