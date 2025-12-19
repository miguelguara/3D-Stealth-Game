using UnityEngine;

public class SFXCotroller : MonoBehaviour
{
    public static SFXCotroller instance;
    private AudioSource audioSource;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
      audioSource = GetComponent<AudioSource>();
    }

    public void TocarSFX(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.PlayOneShot(audio);
    }
    

}
