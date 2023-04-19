using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening.Core.Easing;
using DG.Tweening;

public class UISetting : MonoBehaviour
{
    Dictionary<string, GameObject> _settingdic = new Dictionary<string, GameObject>();

    public bool soundSettingOn = false;

    Tweener _tweener;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _settingdic.Add(transform.GetChild(i).name, transform.GetChild(i).gameObject);
            Debug.Log(_settingdic[transform.GetChild(i).name]);
        }
    }

    public void SoundPanelOnOff()
    {
        _tweener.Kill();
        if (!soundSettingOn)
        {
            SettingPanelOn(_settingdic["SoundSettingButton"].transform.GetChild(1).gameObject);
        }
        else
        {
            SettingPanelOff(_settingdic["SoundSettingButton"].transform.GetChild(1).gameObject);
        }
        soundSettingOn = soundSettingOn == true ? false : true;
    }

    #region SettingOnOffDotween
    private void SettingPanelOn(GameObject setting)
    {
        _tweener = setting.transform.DOScale(new Vector3(10f, 10f, 10f), 0.5f).SetEase(Ease.InExpo).SetEase(Ease.OutBounce).SetUpdate(true);
    }

    private void SettingPanelOff(GameObject setting)
    {
        _tweener = setting.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InExpo).SetEase(Ease.OutBounce).SetUpdate(true);
    }
    #endregion

    public void ReSoulutionOnOff()
    {

    }


    #region ETC
    public void LoadScene()
    {
        SceneMoveManager.Instance.MoveScene("Main");
    }


    #endregion

}
