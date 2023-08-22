using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    //プレイヤーオブジェ取得
    GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの座標を代入(カメラの位置を上にするためにyに500を加える)
        this.transform.position = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y + 20, playerObj.transform.position.z);

        Debug.Log(playerObj.transform.position.y);

        //プレイヤーの角度を代入

        Vector3 rot = playerObj.transform.eulerAngles; // プレイヤーの角度をVector3に直す
        this.transform.rotation = Quaternion.Euler(90, rot.y, 0);
        //this.transform.rotation.x = rot.x;
    }
}
