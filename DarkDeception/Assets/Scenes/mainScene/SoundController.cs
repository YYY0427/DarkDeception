using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource footstepSound;
    public float footStepInterval = 0.5f; // ���s���ʉ��̊Ԋu
    private float nextFootstepTime;

    // Update is called once per frame
    void Update()
    {
        // ���z�̕��s�L�[��ݒ�i��FW�L�[�����s��\���j
        bool isWalking = Input.GetKey(KeyCode.W);

        if (isWalking)
        {
            // ���s���̏ꍇ�A���s���ʉ����Đ�
            if (Time.time >= nextFootstepTime)
            {
                footstepSound.Play();
                nextFootstepTime = Time.time + footStepInterval;
            }
        }
    }
}
