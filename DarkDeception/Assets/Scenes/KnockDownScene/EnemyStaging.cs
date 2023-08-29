using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStaging : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cameraObj;

    public GameObject _Cube;

    private int enemyKind;

    [SerializeField] private GameObject[] enemyObj = new GameObject[5];

    void Start()
    {
        enemyKind = PlayerMove._enemyKind;
       // Instantiate(_enemyObj, this.transform.position, Quaternion.identity);
        cameraObj = GameObject.Find("Main Camera");
        //Instantiate(_Cube, new Vector3(0,0,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //if (_enemyObj.transform.position.y < 0)
        //{
        //    _enemyObj.transform.Translate(0, 0.007f, 0);
        //}

        ////Debug.Log(_Cube.transform.position);

        //Debug.Log(_enemyObj.transform.position);
    }
}
