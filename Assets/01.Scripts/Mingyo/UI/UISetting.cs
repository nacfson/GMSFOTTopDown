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
    GameObject _soundSetting;
    public bool soundSettingOn = false;

    [SerializeField]
    GameObject _resolutionSetting;

    [SerializeField]
    GameObject _reStartSetting;

    [SerializeField]
    GameObject _gotoMainSetting;

    Animator _animator;
    Tweener _tweener;

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
        //Time.timeScale = Time.unscaledDeltaTime;
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
        _tweener.Kill();
        if (!soundSettingOn)
        {
            SettingPanelOn(_soundSetting);
        }
        else
        {
            SettingPanelOff(_soundSetting);
        }
        soundSettingOn = soundSettingOn == true ? false : true;
    }

    private void SettingPanelOn(GameObject setting)
    {
        setting.SetActive(true);
        _tweener = setting.transform.DOScale(new Vector3(10f, 10f, 10f), 0.5f).SetEase(Ease.InExpo).SetEase(Ease.OutBounce).SetUpdate(true);
    }

    private void SettingPanelOff(GameObject setting)
    {
        _tweener = setting.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InExpo).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(()=>
        {
            setting.SetActive(false);
        });
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
    }

}
