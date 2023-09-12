using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public AudioSource soundSource;

    public void PlaySound(AudioClip clip)
    {
        // ‰¹Œ¹‚ğƒ[ƒh
        soundSource.clip = clip;
        if (soundSource != null)
        {
            // ‰¹Œ¹‚ğÄ¶‚·‚é
            soundSource.Play();
        }
    }
    
    public void StopSound()
    {
        // ‰¹Œ¹‚Ì’â~
        soundSource.Stop();
    }

    public void SetVolume(float volume)
    {
        // ‰¹Œ¹‚Ì‰¹—Ê’²®
        soundSource.volume = volume;
    }
}
