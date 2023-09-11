using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class tempCrystal : MonoBehaviour
{
    //�N���X�^���̈ʒu�ɕ\������~�j�}�b�v�pCube
    // private GameObject CrystalCube;

    public AudioClip _collisionSound;   // �Փ˂���ۂɍĐ����鉹
    private AudioSource _audioSource;   

    //static bool isEnable;// ���݂��邩�ǂ���
    void Start()
    {
       // CrystalCube = (GameObject)Resources.Load("CrystalCube");
        Vector3 CrystalCubePos = this.transform.position;
        // CrystalCubePos.y += 5.0f;
        // �v���n�u���w��ʒu�ɐ���
        // CrystalCube = Instantiate(CrystalCube, CrystalCubePos, Quaternion.identity);   

        // AudioSource�R���|�[�l���g���擾
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
            // �������Đ�
            _audioSource.Play();
        }
    }

}
