using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePerformanceEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cameraObj;
    Animator animator;

    bool isPass = false;
    private GameObject _enemyObj;
    void Start()
    {
        _enemyObj = this.gameObject;
        _enemyObj.transform.Rotate(0f, 180f, 0f);
        animator = GetComponentInChildren<Animator>();
        //cameraObj = GameObject.Find("Main Camera");
        //Instantiate(_Cube, new Vector3(0,0,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyObj.transform.position.y < -12f)
        {
            _enemyObj.transform.Translate(0, 0.08f, 0);
        }
        else
        {
            if(!isPass)
            {
                //    animator.SetBool("Attack", true);
                animator.SetTrigger("Attack");
                isPass = true;
            }
        }
    }
}
