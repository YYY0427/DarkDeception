using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class tempCrystal : MonoBehaviour
{
    //クリスタルの位置に表示するミニマップ用Cube
    // private GameObject CrystalCube;

    public AudioClip _collisionSound;   // 衝突する際に再生する音
    private AudioSource _audioSource;   

    //static bool isEnable;// 存在するかどうか
    void Start()
    {
       // CrystalCube = (GameObject)Resources.Load("CrystalCube");
        Vector3 CrystalCubePos = this.transform.position;
        // CrystalCubePos.y += 5.0f;
        // プレハブを指定位置に生成
        // CrystalCube = Instantiate(CrystalCube, CrystalCubePos, Quaternion.identity);   

        // AudioSourceコンポーネントを取得
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _collisionSound;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("A");
           // Destroy(CrystalCube);
            Destroy(this.gameObject);
            // 音源を再生
            _audioSource.Play();
        }
    }

}
