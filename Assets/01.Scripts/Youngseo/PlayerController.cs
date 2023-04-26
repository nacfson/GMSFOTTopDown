using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    float speed;
    public int hp;
    [SerializeField] float xLimit;
    [SerializeField] float yLimit;
    [SerializeField] Image HP;
    [SerializeField] TextMeshProUGUI HpText;
    [SerializeField] PlayerSO _playerSO;
    GunRotate gunRotate;
    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        cam = Camera.main;
        speed = _playerSO.speed;
        hp = _playerSO.hp;
        animator = GetComponent<Animator>();
        gunRotate = FindObjectOfType<GunRotate>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(x, y).normalized * Time.deltaTime * speed;

        if (x != 0 || y != 0) animator.SetBool("Walk", true);
        else animator.SetBool("Walk", false);
        PlayerRotate();

        if (Input.GetKeyDown(KeyCode.X)) Hit();
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

    public void Hit()
    {
        StopCoroutine(Damaged());
        StartCoroutine(Damaged());
    }

    IEnumerator Damaged()
    {
        hp -= 1;
        UpdateHpText();
        spriteRenderer.color = Color.red;
        yield return new WaitForSecondsRealtime(0.3f);
        spriteRenderer.color = Color.white;
    }

    public void UpdateHpText()
    {
        HP.fillAmount = (float)hp / 100;
        HpText.text = hp.ToString() + "%";
    }
}
