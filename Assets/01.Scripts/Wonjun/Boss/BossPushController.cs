using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPushController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 4f;
    [SerializeField]
    private LayerMask _layermask;
    private bool _hasHit = false;
    private bool _canMove = false;
    private SpriteRenderer _spriteRenderer;
    Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        StartCoroutine(FadeInObject());
        _anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasHit && _canMove)
        {
            transform.Translate(Vector2.left * Time.deltaTime * _moveSpeed);
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector3(2, 3, 1), 0, Vector2.zero, _layermask);

            if (hit)
            {
                _hasHit = true;
                Debug.Log("ÇÏ¸ð¿¹");
            }
        }
        else if(_canMove)
        {
            transform.Translate(Vector2.left * Time.deltaTime * _moveSpeed);
        }
    }

    IEnumerator FadeInObject()
    {
        float elapsedTime = 0f;
        float fadeTime = 1f;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeTime);
            _spriteRenderer.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }
        _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        _canMove = true;
        _anim.SetTrigger("BossAttack");

    }

    

    public void PushObject()
    {
        PoolList.instance.Push(gameObject);
    }
}
