using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------- Audio Sources -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------- Audio Clips -----------")]
    public AudioClip backgorund;
    public AudioClip death;
    public AudioClip coin;
    public AudioClip shot;
    public AudioClip jump;
    
    private void Start()
    {
        musicSource.clip = backgorund;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
