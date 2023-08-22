using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    //�v���C���[�I�u�W�F�擾
    GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�̍��W����(�J�����̈ʒu����ɂ��邽�߂�y��500��������)
        this.transform.position = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y + 20, playerObj.transform.position.z);

        Debug.Log(playerObj.transform.position.y);

        //�v���C���[�̊p�x����

        Vector3 rot = playerObj.transform.eulerAngles; // �v���C���[�̊p�x��Vector3�ɒ���
        this.transform.rotation = Quaternion.Euler(90, rot.y, 0);
        //this.transform.rotation.x = rot.x;
    }
}
