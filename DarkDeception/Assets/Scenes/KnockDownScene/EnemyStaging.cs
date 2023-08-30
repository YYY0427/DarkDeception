using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStaging : MonoBehaviour
{
    private int enemyKind;

    [SerializeField] private GameObject[] enemyObj = new GameObject[5];

    private GameObject _enemyObj;

    void Start()
    {
        enemyKind = PlayerMove._enemyKind;

        //enemyKind = 1;

        _enemyObj = enemyObj[enemyKind];

        Instantiate(_enemyObj, this.transform.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
