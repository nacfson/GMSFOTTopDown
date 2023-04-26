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

    private bool soundSettingOn = false;
    private bool reSoulutionSettingOn = false;

    Tweener _tweener;
    Vector3 onScale = new Vector3(7f, 7f, 7f);

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _settingdic.Add(transform.GetChild(i).name, transform.GetChild(i).gameObject);
            Debug.Log(_settingdic[transform.GetChild(i).name]);
        }
    }

    #region PanelOnOff

    public void SoundPanelOnOff()
    {
        _tweener.Kill();
        Button btn = _settingdic["SoundSettingButton"].GetComponent<Button>();
        if (!soundSettingOn)
        {
            btn.interactable = false;
            SettingPanelOn(btn.transform.GetChild(1).gameObject);
        }
        else
        {
            btn.interactable = true;
            SettingPanelOff(btn.transform.GetChild(1).gameObject);
        }
        soundSettingOn = soundSettingOn == true ? false : true;
    }

    public void ReSoulutionOnOff()
    {
        _tweener.Kill();
        Button btn = _settingdic["ResolutionSettingButton"].GetComponent<Button>();
        if (!reSoulutionSettingOn)
        {
            btn.interactable = false;
            SettingPanelOn(btn.transform.GetChild(1).gameObject);
        }
        else
        {
            btn.interactable = true;
            SettingPanelOff(btn.transform.GetChild(1).gameObject);
        }
        reSoulutionSettingOn = reSoulutionSettingOn == true ? false : true;
    }

    #endregion

    #region SettingOnOffDotween
    private void SettingPanelOn(GameObject setting)
    {
        _tweener = setting.transform.DOScale(onScale, 0.5f).SetEase(Ease.InExpo).SetEase(Ease.OutBounce).SetUpdate(true);
    }

    private void SettingPanelOff(GameObject setting)
    {
         setting.gameObject.SetActive(true);
        _tweener = setting.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InExpo).SetEase(Ease.OutBounce).SetUpdate(true);
    }
    #endregion

    #region ETC
    public void LoadScene()
    {
        SceneMoveManager.Instance.MoveScene("Main");
    }
    #endregion

}
