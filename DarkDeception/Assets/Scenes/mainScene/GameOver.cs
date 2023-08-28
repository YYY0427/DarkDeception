using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject canvasObj;

    public static GameObject enemyObj;

    public static bool gameOver;
    void Start()
    {
        canvasObj = GameObject.Find("GameOverBackGround");
        canvasObj.SetActive(false);
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameOver = true;
        if (gameOver)
        {
            canvasObj.SetActive(true);
            Debug.Log("unti");
        }
    }
}
