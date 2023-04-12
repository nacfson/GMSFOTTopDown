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
    Transform startPos;
    [SerializeField]
    Transform endPos;


    [SerializeField]
    GameObject _settingManager;
    private bool settingManagerOn = false;

    [SerializeField]
    Image _soundSetting;
    public bool soundSettingOn = false;

    [SerializeField]
    GameObject _resolutionSetting;

    [SerializeField]
    GameObject _reStartSetting;

    [SerializeField]
    GameObject _gotoMainSetting;

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
        Time.timeScale = Time.unscaledDeltaTime;
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
        settingManagerOn = settingManagerOn == true ? false: true;
    }

    public void SoundPanelOnOff()
    {
        if(!soundSettingOn)
        {
            SettingPanelOn(_soundSetting);
        }
        else
        {
            SettingPanelOff(_soundSetting);
        }
        soundSettingOn = soundSettingOn == true ? false : true;
    }

    private void SettingPanelOn(Image setting)
    {
        setting.rectTransform.DOMove(endPos.transform.position, 0.1f);
    }

    private void SettingPanelOff(Image setting)
    {
        setting.rectTransform.DOMove(startPos.transform.position, 0.1f);
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
        //GameManager.Instance.GameTimeControll();
    }

}
