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
        }
        else
        {
            width = Screen.width;
            height = Screen.height;
        }

        
        Screen.SetResolution(width, height, true);
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

    public void OKButtonClick()
    {
        Screen.SetResolution(resolutionsList[resolutionNum].width, resolutionsList[resolutionNum].height, _screenMode);
        PlayerPrefs.SetInt("width", resolutionsList[resolutionNum].width);
        PlayerPrefs.SetInt("height", resolutionsList[resolutionNum].height);
    }

    public void FullBtn()
    {
        //screenMode = FullScreenMode.FullScreenWindow;
        _screenMode = _screenMode == FullScreenMode.FullScreenWindow ? FullScreenMode.Windowed : FullScreenMode.FullScreenWindow;
    }
    public void ScreenBtn()
    {
        //screenMode = FullScreenMode.Windowed;
    }

}
