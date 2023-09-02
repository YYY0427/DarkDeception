using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{

    public static SE Instance;

    public AudioClip sound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void daggerSound()
    {
        audioSource.PlayOneShot(sound);
    }

    public void bloodSound()
    {
        audioSource.PlayOneShot(sound);
    }

}
