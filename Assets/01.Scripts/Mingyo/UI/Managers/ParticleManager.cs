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

    public void SFXPlay(GameObject particle)
    {
        ParticleSystem obj = particle.GetComponent<ParticleSystem>();
        obj.Play();
        Destroy(obj, obj.startLifetime);
    }

}
