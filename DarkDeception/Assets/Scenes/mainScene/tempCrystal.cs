using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class tempCrystal : MonoBehaviour
{
    //�N���X�^���̈ʒu�ɕ\������~�j�}�b�v�pCube
    // private GameObject CrystalCube;
    //static bool isEnable;// ���݂��邩�ǂ���

    private SoundManager soundManager;  // �T�E���h�}�l�[�W���[�̎Q��
    [SerializeField] private AudioClip collisionSound = default;   // �Փˎ��̉�

    void Start()
    {
       // CrystalCube = (GameObject)Resources.Load("CrystalCube");
        Vector3 CrystalCubePos = this.transform.position;
        // CrystalCubePos.y += 5.0f;
        // �v���n�u���w��ʒu�ɐ���
        // CrystalCube = Instantiate(CrystalCube, CrystalCubePos, Quaternion.identity);   

        // �T�E���h�}�l�[�W���[�̃C���X�^���X�������ĎQ��
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayCollisionSound();
            DontDestroyOnLoad(soundManager);

            // �N���X�^��������
            Destroy(this.gameObject);
        }
    }
    private void PlayCollisionSound()
    {
        // ���ʒ���������
        soundManager.SetVolume(0.2f);
        // �T�E���h�}�l�[�W���[���g�p���ĉ������Đ�
        soundManager.PlaySound(collisionSound);
    }
}
