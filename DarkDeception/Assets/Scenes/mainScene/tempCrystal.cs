using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class tempCrystal : MonoBehaviour
{
    //クリスタルの位置に表示するミニマップ用Cube
   // private GameObject CrystalCube;

    //static bool isEnable;// 存在するかどうか
    void Start()
    {
       // CrystalCube = (GameObject)Resources.Load("CrystalCube");
        Vector3 CrystalCubePos = this.transform.position;
       // CrystalCubePos.y += 5.0f;
        // プレハブを指定位置に生成
       // CrystalCube = Instantiate(CrystalCube, CrystalCubePos, Quaternion.identity);   
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("A");
           // Destroy(CrystalCube);
            Destroy(this.gameObject);
        }
    }

}
