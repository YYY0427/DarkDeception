using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject canvasObj;
    void Start()
    {
        canvasObj = this.gameObject;
        canvasObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMove.gameOver)
        {
            canvasObj.SetActive(true);
        }
    }
}
