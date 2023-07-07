using UnityEngine;

[System.Serializable]
public class Class_Sound : MonoBehaviour
{
    #region Class Properties: 

    public string clipName;
    public AudioClip audioClip;
    public bool audioLoop;
    //--------------------------
    [Range(0f, 1f)]
    public float audioVolume;
    [Range(0.1f, 3f)]
    public float audioPitch;
    //--------------------------
    [HideInInspector]
    public AudioSource audioSource;
    
    #endregion
}
