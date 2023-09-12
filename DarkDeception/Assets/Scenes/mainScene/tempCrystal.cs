using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class tempCrystal : MonoBehaviour
{
    //クリスタルの位置に表示するミニマップ用Cube
    // private GameObject CrystalCube;
    //static bool isEnable;// 存在するかどうか

    private SoundManager soundManager;  // サウンドマネージャーの参照
    [SerializeField] private AudioClip collisionSound = default;   // 衝突時の音

    void Start()
    {
       // CrystalCube = (GameObject)Resources.Load("CrystalCube");
        Vector3 CrystalCubePos = this.transform.position;
        // CrystalCubePos.y += 5.0f;
        // プレハブを指定位置に生成
        // CrystalCube = Instantiate(CrystalCube, CrystalCubePos, Quaternion.identity);   

        // サウンドマネージャーのインスタンスを見つけて参照
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayCollisionSound();
            DontDestroyOnLoad(soundManager);

            // クリスタルを消す
            Destroy(this.gameObject);
        }
    }
    private void PlayCollisionSound()
    {
        // 音量調整をする
        soundManager.SetVolume(0.2f);
        // サウンドマネージャーを使用して音声を再生
        soundManager.PlaySound(collisionSound);
    }
}
