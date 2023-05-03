using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransformation : MonoBehaviour
{
    bool Form = false;
    PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        StartCoroutine(HpMinus());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Transformation();
        }
    }
    private void Transformation()
    {
        if (!Form)
        {
            
            Form = true;
        }
        else
        {
            
            Form = false;
        }
    }

    IEnumerator HpMinus()
    {
        while (true)
        {
            if (Form && playerController.hp > 30)
            {
                playerController.hp -= 1;
                playerController.UpdateHpText();
                yield return new WaitForSeconds(1);
            }
            yield return 0;
        }
    }
}
