using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening.Core.Easing;
using DG.Tweening;

public class UISetting : MonoBehaviour
{

    [SerializeField]
    RectTransform _settingManager;
    public bool _settingManagerOn = false;

    [SerializeField]
    Button _soundSettingButton;

    [SerializeField]
    Button _resolutionSettingButton;

    [SerializeField]
    Button _reStartButton;

    [SerializeField]
    Button _gotoMainButton;

    Animator _animator;

    private void Awake()
    {
        _animator = transform.GetComponentInChildren<Animator>();
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
        if (!_settingManagerOn)
        {
            _animator.SetTrigger("SettingManagerOn");
        }
        else
        {
            _animator.SetTrigger("SettingManagerOff");
        }
        _settingManagerOn = _settingManagerOn == true ? false: true;
    }

    public void SoundPanelOnOff()
    {

    }

    public void ReSoulutionOnOff()
    {

    }

    public void LoadScene()
    {
        GameManager.Instance.MoveScene("Main");
    }

    public void GameTimeControll()
    {
        GameManager.Instance.GameTimeControll();
        Debug.Log(Time.deltaTime);
    }

}
