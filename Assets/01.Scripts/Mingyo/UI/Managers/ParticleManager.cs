using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SFXPlay(ParticleSystem particle, Vector2 transform)
    {
        ParticleSystem _particle = particle.GetComponent<ParticleSystem>();
        Instantiate(_particle, transform, Quaternion.identity);
        _particle.Play();
        //Ç®¸µ ÇØ¾ßµÊ
    }

}
