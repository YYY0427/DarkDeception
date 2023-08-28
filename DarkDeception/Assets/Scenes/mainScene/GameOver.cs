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
            canvasObj.SetActive(true);
            enemyObj.transform.rotation = cameraObj.transform.rotation;
            enemyObj.transform.Translate(0, 180, 0);

            // カメラの向きを基準にした正面方向のベクトル
            Vector3 cameraForward = Vector3.Scale(transform.forward, new Vector3(1, 0, 1)).normalized;


        }
    }
}
