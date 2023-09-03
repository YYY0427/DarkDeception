using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentMove : MonoBehaviour
{
    public Transform pos;
    private Rigidbody rb;

    Vector3 initPos;
    int timer = 0;
    bool isMove = false;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isMove)
        {
            transform.position += new Vector3(0, 0, -1) * Time.deltaTime * 500.0f;

            if (transform.position.z <= pos.position.z)
            {
                isMove = false;
                transform.position = initPos;
            }
        }
        else
        {
            timer++;
            if (timer > 600)
            {
                isMove = true;
                timer = 0;
            }
        }
    }
}
