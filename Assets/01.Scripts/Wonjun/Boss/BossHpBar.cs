using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHpBar : MonoBehaviour
{
    [SerializeField]
    private Transform _HpBar;

    public void HpGaugeNormal(float value)
    {
        _HpBar.transform.localScale = new Vector3(value, 1, 1);
    }
}
