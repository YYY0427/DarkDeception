using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (reopen.clickButton)
        {
            audio.volume = System.Math.Max(audio.volume - 0.01f, 0.0f);
            if (audio.volume <= 0.0f)
            {
                reopen.clickButton = false;
            }
        }
        else
        {
            audio.volume = System.Math.Min(audio.volume + 0.001f, 0.3f);
        }
    }


}
