using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class tempCrystal : MonoBehaviour
{
    //�N���X�^���̈ʒu�ɕ\������~�j�}�b�v�pCube
    // private GameObject CrystalCube;

    //public AudioClip _collisionSound;   // �Փ˂���ۂɍĐ����鉹
    public AudioSource _audioSource;
    //timer
    int _destroyTimer = 0;
    bool _destroyFlag = false;

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
