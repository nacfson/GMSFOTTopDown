using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/Enemy/EnemySO")]
public class EnemySO : ScriptableObject
{
    public float speed;
    public float attack;
    public float follow;
    public float hp;
    public ParticleSystem bloodParticle;
}
