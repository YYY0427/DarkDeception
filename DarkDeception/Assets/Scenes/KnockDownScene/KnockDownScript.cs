using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnockDownScript : MonoBehaviour
{
    private int _nextSceneFrame;    // 次のシーンに移行するまでの時間
    public AudioSource _audioSource;
    void Start()
    {
        _nextSceneFrame = 150;
        // AudioSourceのコンポーネント取得
        _audioSource = GetComponent<AudioSource>();
        // 音楽再生
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
