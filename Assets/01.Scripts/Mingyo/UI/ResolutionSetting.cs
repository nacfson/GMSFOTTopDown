using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionSetting : MonoBehaviour
{
    [SerializeField] Toggle _fullScreenBtn;
    [SerializeField] TMP_Dropdown _resolutionDropDown;
    [SerializeField] ResolutionListSO _resolutionSOList;

    FullScreenMode _screenMode;
    List<Resolution> resolutionsList = new List<Resolution>();
    int resolutionNum;

    private void Start()
    {
        int width;
        int height;
        if(PlayerPrefs.GetInt("width") != 0)
        {
            width = PlayerPrefs.GetInt("width");
            height = PlayerPrefs.GetInt("height");
            if((PlayerPrefs.GetInt("screenmode") == 0))
            {
                _screenMode = FullScreenMode.Windowed;
            }
            else
            {
                _screenMode = FullScreenMode.FullScreenWindow;
            }
        }
        else
        {
            width = 1920;
            height = 1080;
            _fullScreenBtn.isOn = false;
        }

        Screen.SetResolution(width, height, _screenMode);
        InitUI();
    }

    void InitUI()
    {
        //for (int i = 0; i < Screen.resolutions.Length; i++)
        //{
        //    if (Screen.resolutions[i].refreshRate == 59 || Screen.resolutions[i].refreshRate == 60)
        //    {
        //        resolutionsList.Add(Screen.resolutions[i]);
        //    }
        //}

        //resolutionsList.Reverse();

        for(int i = 0; i < 15; i++)
        {
            Resolution resolution = Screen.resolutions[0];
            resolution.width = _resolutionSOList.width[i];
            resolution.height = _resolutionSOList.height[i];
            resolutionsList.Add(resolution);
        }

        _resolutionDropDown.options.Clear();

        int optionNum = 0;

        foreach (Resolution item in resolutionsList)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData();
            optionData.text = item.width + "X" + item.height;
            _resolutionDropDown.options.Add(optionData);

            if (item.width == Screen.width && item.height == Screen.height)
            {
                _resolutionDropDown.value = optionNum;
                optionNum++;
            }
        }
        _resolutionDropDown.RefreshShownValue();

        _fullScreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }

    public void DropDownOptionChange(int a)
    {
        resolutionNum = a;
    }

    public void ResolutionChange()
    {
        Screen.SetResolution(resolutionsList[resolutionNum].width, resolutionsList[resolutionNum].height, _screenMode);
        PlayerPrefs.SetInt("width", resolutionsList[resolutionNum].width);
        PlayerPrefs.SetInt("height", resolutionsList[resolutionNum].height);
    }

    public void FullBtn()
    {
        //screenMode = FullScreenMode.FullScreenWindow;
        if(_screenMode == FullScreenMode.FullScreenWindow)
        {
            _screenMode = FullScreenMode.Windowed;
            PlayerPrefs.SetInt("screenmode", 0);
        }
        else
        {
            _screenMode = FullScreenMode.FullScreenWindow;
            PlayerPrefs.SetInt("screenmode", 1);

        }
    }
}
