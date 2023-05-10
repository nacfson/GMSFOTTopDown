using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/Player/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public float speed;
    public float damage;
    public float reload;
    public float bulletSpeed;
    public float shootDelay;
    public int hp;
}
