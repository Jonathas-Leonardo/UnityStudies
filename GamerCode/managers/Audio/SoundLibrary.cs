using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibrary : MonoBehaviour {

    public SoundGroup[] soundLibrary;

    Dictionary<string, AudioClip> soundDictionary = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        foreach (SoundGroup item in soundLibrary)
        {
            foreach (Sound sound_item in item.sounds)
            {
                soundDictionary.Add(sound_item.nameSound, sound_item.clips);
            }          
        }
    }

    public AudioClip GetClipFromName(string name)
    {
        if (soundDictionary.ContainsKey(name))
        {
            return soundDictionary[name];
        }

        return null;
    }

    [System.Serializable]
    public class SoundGroup
    {
        public string nameGroup;
        public Sound[] sounds;
    }

    [System.Serializable]
    public class Sound
    {
        public string nameSound;
        public AudioClip clips;
    }
}
