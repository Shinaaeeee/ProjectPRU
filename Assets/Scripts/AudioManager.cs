using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource effectaudioSource;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip ReloadClip;
    [SerializeField] private AudioClip energyClip;
    [SerializeField] private AudioSource defaultAudioSource;
    [SerializeField] private AudioSource bossAudioSource;

    public void PlayShootSound()
    {
        effectaudioSource.PlayOneShot(shootClip);
    }
    public void PlayReloadSound()
    {
        effectaudioSource.PlayOneShot(ReloadClip);
    }
    public void PlayEnergySound()
    {
        effectaudioSource.PlayOneShot(energyClip);
    }
    public void PlayDefaultAudioSource()
    {
        defaultAudioSource.Play();
        bossAudioSource.Stop();
    }
    public void PlayBossSound() {
        defaultAudioSource.Stop();
        bossAudioSource.Play();

    } 
    public void StopAudioGame()
    {
        effectaudioSource.Stop();
        bossAudioSource.Stop();
        defaultAudioSource.Stop();
    }

}
