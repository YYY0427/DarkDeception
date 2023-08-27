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

        obj.transform.position = cameraObj.transform.position;
        obj.transform.position += new Vector3(0, -2.0f, 1.0f);

        obj.transform.rotation = cameraObj.transform.rotation;
        obj.transform.Rotate(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (obj.transform.position.y < cameraObj.transform.position.y - 0.8f)
        {
            obj.transform.Translate(0, 0.007f, 0);
        }

        Debug.Log(cameraObj.transform.position);
    }
}
