using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cameraObj;

    private GameObject _enemyObj;
    void Start()
    {
        _enemyObj = this.gameObject;
        _enemyObj.transform.Rotate(0f, 180f, 0f);
        //cameraObj = GameObject.Find("Main Camera");
        //Instantiate(_Cube, new Vector3(0,0,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyObj.transform.position.y < 0)
        {
            _enemyObj.transform.Translate(0, 0.007f, 0);
        }

        //Debug.Log(_Cube.transform.position);

        Debug.Log(_enemyObj.transform.position);
    }
}
