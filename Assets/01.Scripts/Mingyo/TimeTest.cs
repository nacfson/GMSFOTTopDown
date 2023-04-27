using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTest : MonoBehaviour
{
    [SerializeField]
    private AudioSource SFX;

    [SerializeField]
    ParticleSystem SFXParticleSystem;

    void Start()
    {
        SFX = GetComponent<AudioSource>();

    }

    void Update()
    {
        //transform.Translate(Vector3.right * 5f * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.Instance.SFXPlay(SFX);
        }
    }
}
