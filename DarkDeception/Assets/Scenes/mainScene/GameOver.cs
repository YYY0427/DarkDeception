using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject canvasObj;

    public static GameObject enemyObj;

    GameObject cameraObj;

    public static bool gameOver;
    void Start()
    {
        canvasObj = GameObject.Find("GameOverBackGround");
        cameraObj = GameObject.Find("Camera");
        canvasObj.SetActive(false);
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            //canvasObj.SetActive(true);
            enemyObj.transform.rotation = cameraObj.transform.rotation;
            enemyObj.transform.Translate(180, 0, 0);

            // カメラの向きを基準にした正面方向のベクトル
            Vector3 cameraForward = cameraObj.transform.forward.normalized * 10;
            Vector3 cameraDown = cameraObj.transform.up.normalized * 10;
            cameraDown.y *= -1;

            enemyObj.transform.position = cameraForward + cameraObj.transform.position + cameraDown;

        }
    }
}
