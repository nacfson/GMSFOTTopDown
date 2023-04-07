using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    float speed = 5f;
    bool Form = false;
    public float xLimit;
    public float yLimit;
    public float hp = 3f;

    private void Awake()
    {
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(x, y).normalized * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Transformation();
        }
    }

    private void LateUpdate()
    {
        float x = Mathf.Clamp(transform.position.x, -xLimit, xLimit);
        float y = Mathf.Clamp(transform.position.y, -yLimit, yLimit);
        transform.position = new Vector2(x, y);
    }

    private void Transformation()
    {
        if (!Form)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            Form = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            Form = false;
        }
    }
    public void Damage()
    {
        hp--;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
