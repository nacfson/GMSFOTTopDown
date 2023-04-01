using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    [SerializeField]
    GameObject _settingManager;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            bool onOff = onOff = true ? false : true;
            _settingManager.SetActive(onOff);
        }
    }
}
