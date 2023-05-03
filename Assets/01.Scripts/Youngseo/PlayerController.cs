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
    [SerializeField] PlayerSO playerSO;
    Animator animator;
    PlayerGunRotate gunRotate;

    private void Awake()
    {
        cam = Camera.main;
        speed = playerSO.speed;
        hp = playerSO.hp;
        animator = GetComponent<Animator>();
        gunRotate = transform.Find("Gun").GetComponent<PlayerGunRotate>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x, y).normalized * Time.deltaTime * speed;
        PlayerRotate();

        if (Input.GetKeyDown(KeyCode.X)) Hit(5);
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
            gunRotate.Flip(transform.localScale.x);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            gunRotate.Flip(transform.localScale.x);
        }
    }

    public void Hit(int damage)
    {
        hp -= damage;
        UpdateHpText();
        if (hp <= 0) PlayerDie();

        StopCoroutine(Damaged());
        StartCoroutine(Damaged());
    }

    IEnumerator Damaged()
    {
        speed = 0;
        animator.SetBool("Hit", true);
        yield return new WaitForSecondsRealtime(0.2f);
        if (hp > 0) speed = playerSO.speed;
        animator.SetBool("Hit", false);
    }

    public void UpdateHpText()
    {
        HP.fillAmount = (float)hp / 100;
        HpText.text = hp.ToString() + "%";
    }

    void PlayerDie()
    {
        hp = 0;
        UpdateHpText();
        animator.SetTrigger("Die");
    }

    public void PlayerDieEvent()
    {
        gameObject.SetActive(false);
    }
}
