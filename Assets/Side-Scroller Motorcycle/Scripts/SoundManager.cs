using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //public static SoundManager Instance;

    //public AudioSource audioSource;
    public bool soundOn = true;

    //private void Awake()
    //{
    //    if (Instance != null)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }

    //    Instance = this;
    //    DontDestroyOnLoad(gameObject);
    //}

    public void Sounds_On()
    {
        AudioListener.volume = 1;
        soundOn = true;
        MainManager.Instance.GameSounds = true;
    }

    public void Sounds_Off()
    {
        AudioListener.volume = 0;
        soundOn = false;
        MainManager.Instance.GameSounds = false;
    }
}
