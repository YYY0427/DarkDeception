using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnockDownScript : MonoBehaviour
{
    private int _nextSceneFrame;    // ���̃V�[���Ɉڍs����܂ł̎���
    public AudioSource _audioSource;
    void Start()
    {
        _nextSceneFrame = 150;
        // AudioSource�̃R���|�[�l���g�擾
        _audioSource = GetComponent<AudioSource>();
        // ���y�Đ�
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _nextSceneFrame--;

        if (_nextSceneFrame < 0)
        {
            PlayerLife.lifeDecrease();
            PlayerLife.changeScene();
        }
        Debug.Log(_nextSceneFrame);
    }
}
