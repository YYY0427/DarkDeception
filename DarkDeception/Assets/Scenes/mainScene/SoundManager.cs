using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public AudioSource soundSource;

    public void PlaySound(AudioClip clip)
    {
        // ���������[�h
        soundSource.clip = clip;
        if (soundSource != null)
        {
            // �������Đ�����
            soundSource.Play();
        }
    }
    
    public void StopSound()
    {
        // �����̒�~
        soundSource.Stop();
    }

    public void SetVolume(float volume)
    {
        // �����̉��ʒ���
        soundSource.volume = volume;
    }
}
