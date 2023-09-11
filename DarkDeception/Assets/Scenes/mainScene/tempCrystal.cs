using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class tempCrystal : MonoBehaviour
{
    //クリスタルの位置に表示するミニマップ用Cube
    // private GameObject CrystalCube;

    //public AudioClip _collisionSound;   // 衝突する際に再生する音
    public AudioSource _audioSource;
    //timer
    int _destroyTimer = 0;
    bool _destroyFlag = false;

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
        //_audioSource.clip = _collisionSound;
    }

    private void Update()
    {
        if(_destroyTimer > 8)
        {
            //Destroy(this.gameObject);
            //_audioSource.Play
        }
        else if(_destroyFlag)
        {
            //_destroyTimer++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            _audioSource.Play();
            //_destroyFlag = true;
        }
    }
}
