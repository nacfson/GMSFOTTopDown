using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{
    [SerializeField]
    GameObject _settingManager;
    public bool _settingManagerOn = true;

    [SerializeField]
    Button _soundSettingButton;

    [SerializeField]
    Button _resolutionSettingButton;

    [SerializeField]
    Button _reStartButton;

    [SerializeField]
    Button _gotoMainButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingPanelOnOff();
        }
    }

    public void SettingPanelOnOff()
    {
        //_settingManager.SetActive(_settingManagerOnOff);
        if(_settingManagerOn)
        {
            _settingManager.transform.DOMoveY(585, 1);
        }
        else
        {
            _settingManager.transform.DOMoveY(-200, 1);
        }
        _settingManagerOn = _settingManagerOn == true ? false : true;
        GameManager._instance.GameStop();
    }

    public void SoundPanelOnOff()
    {

    }

    public void ReSoulutionOnOff()
    {

    }

    public void LoadScene()
    {
        GameManager._instance.MoveScene("Main");
    }
}
