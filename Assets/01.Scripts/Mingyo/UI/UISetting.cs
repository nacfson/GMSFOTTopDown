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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingPanelOnOff();
        }
    }

    public void SettingPanelOnOff()
    {
        if (_settingManagerOn)
        {
            
        }
        else
        {
            
        }

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
}
