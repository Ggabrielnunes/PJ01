using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

    private AudioSource _source;
    private static SFXManager instance;
   
    public static SFXManager Instance
    {
        get { return instance ?? (instance = new GameObject("SFXManager").AddComponent<SFXManager>()); }
    }

    public void KInitialize()
    {
        if(_source==null)
        {
            _source = gameObject.AddComponent<AudioSource>();
            _source.volume = 0.5f;
        }
        DontDestroyOnLoad(this);
    }

    public void SetVolume(float p_volume)
    {
        _source.volume = p_volume;
    }

    public void PlaySFX(AudioClip p_sfx)
    {
        _source.PlayOneShot(p_sfx);
    }

    public float GetVolume()
    {
        return _source.volume;
    }
}
