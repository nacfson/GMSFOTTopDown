using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelUp : MonoBehaviour
{
    public int Exp;
    public int ExpLimit = 20;
    public int Level;

    public void AddExp()
    {
        Exp += 5;
        Debug.Log(Exp);
        LevelUp();
    }

    public void LevelUp()
    {
        if (Exp >= ExpLimit)
        {
            Level += 1;
            ExpLimit += 5;
            Debug.Log(Level);
        }
    }
}
