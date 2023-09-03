using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSE : MonoBehaviour
{

    GameObject kamiObj;
    SpriteRenderer kami;
    public AudioClip sound;
    AudioSource audio;

    bool soundPlaying;

    // Start is called before the first frame update
    void Start()
    {
        kamiObj = GameObject.Find("kami000");
        kami = kamiObj.GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();

        soundPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!soundPlaying)
        {
            if (kami.sprite.name == "kami000")
            {
                audio.PlayOneShot(sound);
                Debug.Log(kami.sprite.name);
                soundPlaying = true;
            }
        }
        else if(kami.sprite.name == "kami298")
        {
            soundPlaying = false;
        }
    }

    private void FixedUpdate()
    {
        
        
    }

}
