using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevelUp : MonoBehaviour
{
    public Image EXP;
    float Exp = 0f;
    int ExpLimit = 20;
    int Level = 1;
    public TextMeshProUGUI _Level;
    PlayerShoot playerShoot;

    private void Awake()
    {
        playerShoot = FindObjectOfType<PlayerShoot>();
    }

    private void Start()
    {
        _Level.text = "Lv. 1";
    }

    public void AddExp()
    {
        Exp += 5;
        EXP.fillAmount = Exp / ExpLimit;
        LevelUp();
    }

    void LevelUp()
    {
        if (Exp >= ExpLimit)
        {
            Level += 1;
            Exp -= ExpLimit;
            EXP.fillAmount = Exp / ExpLimit;
            ExpLimit += 8;
            _Level.text = "Lv. " + Level.ToString();
            if (playerShoot.shootDelay > 0.15f) playerShoot.shootDelay -= 0.05f;
        }
    }
}
