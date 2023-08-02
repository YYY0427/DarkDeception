using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    GameObject enemyObj;

    Vector3 enemyPos;
    // Start is called before the first frame update
    void Start()
    {
        enemyObj = GameObject.Find("Enemy");
        enemyPos = enemyObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(enemyPos.x, enemyPos.y + 500, enemyPos.z);

        enemyPos = enemyObj.transform.position;
    }
}
