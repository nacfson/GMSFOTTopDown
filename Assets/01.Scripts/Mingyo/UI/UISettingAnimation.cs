using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISettingAnimation : MonoBehaviour
{
    [SerializeField]
    GameObject _settingManager;
    Animator _animator;
    private bool settingManagerOn = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingPanelOnOff();
        }
    }

    public void SettingPanelOnOff()
    {
        if (!settingManagerOn)
        {
            _animator.SetTrigger("SettingManagerOn");
        }
        else
        {
            _animator.SetTrigger("SettingManagerOff");
        }
        settingManagerOn = settingManagerOn == true ? false : true;
    }

    public void GameTimeControll()
    {
        GameManager.Instance.GameTimeControll();
    }
}
