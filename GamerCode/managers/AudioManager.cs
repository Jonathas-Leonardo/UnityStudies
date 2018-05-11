using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource soundUI;
    public AudioSource soundBGM;
    public AudioSource[] soundSE;

    public static AudioManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void PlayBGM(AudioClip clip)
    {
        soundBGM.clip = clip;
        soundBGM.Play();
    }

    public void PlayUI(AudioClip clip)
    {
        soundUI.clip = clip;
        soundUI.Play();
    }

    public void PlaySE(AudioClip clip, int index)
    {
        soundSE[index].clip = clip;
        soundSE[index].Play();
    }

    //public void PlaySE(AudioClip clip)
    //{
    //    int index = 0;
    //    if (soundSE[index].isPlaying)
    //    {
    //        index++;
    //        index = (index % soundSE.Length);
    //    }
    //    soundSE[index].clip = clip;
    //    soundSE[index].Play();
    //}
}
