using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class tempCrystal : MonoBehaviour
{
    //�N���X�^���̈ʒu�ɕ\������~�j�}�b�v�pCube
   // private GameObject CrystalCube;

    //static bool isEnable;// ���݂��邩�ǂ���
    void Start()
    {
       // CrystalCube = (GameObject)Resources.Load("CrystalCube");
        Vector3 CrystalCubePos = this.transform.position;
       // CrystalCubePos.y += 5.0f;
        // �v���n�u���w��ʒu�ɐ���
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
