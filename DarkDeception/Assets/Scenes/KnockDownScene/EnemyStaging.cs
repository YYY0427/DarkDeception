using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStaging : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject obj;
    GameObject cameraObj;

    void Start()
    {
        obj = this.GameObject();
        cameraObj = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (obj.transform.position.y < 0)
        {
            obj.transform.Translate(0, 0.007f, 0);
        }

        Debug.Log(cameraObj.transform.position);
    }
}
