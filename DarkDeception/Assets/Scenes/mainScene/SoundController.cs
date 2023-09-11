using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource footstepSound;
    public float footStepInterval = 0.5f; // 歩行効果音の間隔
    private float nextFootstepTime;

    // Update is called once per frame
    void Update()
    {
        // 仮想の歩行キーを設定（例：Wキーが歩行を表す）
        bool isWalking = Input.GetKey(KeyCode.W);

        if (isWalking)
        {
            // 歩行中の場合、歩行効果音を再生
            if (Time.time >= nextFootstepTime)
            {
                footstepSound.Play();
                nextFootstepTime = Time.time + footStepInterval;
            }
        }
    }
}
