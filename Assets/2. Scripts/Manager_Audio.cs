using System;
using UnityEngine;

public class Manager_Audio : MonoBehaviour
{
    #region Variables to use: 

    // Private non-visible variables: 
    public static Manager_Audio Instance;

    [Header("List of clips: ")]
    public Class_Sound[] sounds;

    #endregion

    // Awake is called before any other method 
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Class_Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();

            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.audioVolume;
            s.audioSource.pitch = s.audioPitch;
            s.audioSource.loop = s.audioLoop;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Not used at the moment. 
    }

    // Update is called once per frame
    void Update()
    {
        // Not used at the moment. 
    }

    #region Methods in use: 

    public void PlayAudio(string name)
    {
        Class_Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " has not been found! ");
            return;
        }

        s.audioSource.Play();
    }

    public void StopAudio(string name)
    {
        Class_Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " has not been found! ");
            return;
        }

        s.audioSource.Stop();
    }

    #endregion
}
