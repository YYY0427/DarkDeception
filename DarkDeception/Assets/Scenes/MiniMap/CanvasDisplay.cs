using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    // Canvasオブジェ取得
    GameObject canvasObj;

    bool active;

    void Start()
    {
        canvasObj = GameObject.Find("Canvas");
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            active = !active;
        }

        canvasObj.SetActive(active);
    }

    private void FixedUpdate()
    {
        
    }
}
