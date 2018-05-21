using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance = null;

    [Range(0, 1)]
    public float masterVolume;
    [Range(0, 1)]
    public float sfxVolume;
    [Range(0, 1)]
    public float musicVolume;

    AudioSource[] audioSource_List;

    SoundLibrary soundLibrary;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);

        audioSource_List = GetComponentsInChildren<AudioSource>();
        soundLibrary = GetComponent<SoundLibrary>();
    }

    void AdjustVolumeWithMaster()
    {
        audioSource_List[0].volume = musicVolume * masterVolume;

        for (int i = 1; i < audioSource_List.Length; i++)
        {
            audioSource_List[i].volume = sfxVolume * masterVolume;
        }
    }

    public void AddClipToChannel(AudioClip clip)
    {
        for (int i = 0; i < audioSource_List.Length; i++)
        {
            //Debug.Log("Channel "+i);
            if (!audioSource_List[i].isPlaying)
            {
                audioSource_List[i].clip = clip;
                audioSource_List[i].Play();
                break;
            }
        }
    }

    public void PlaySoundByName(string name)
    {
        AudioClip clip = soundLibrary.GetClipFromName(name);
        AddClipToChannel(clip);
    }

}
