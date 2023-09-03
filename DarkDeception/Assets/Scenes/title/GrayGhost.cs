using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayGhost : MonoBehaviour
{
    public Transform point;
    public float speed = 10f; // ˆÚ“®‚Ì‘¬“x‚ðŽw’è
    private Rigidbody rb;
    private Transform objectTransform;

    int state = 0;
    int timer = 0;
    int timer2 = 0;
    bool isForward = false;
    bool isBack = false;
    Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        rb = GetComponent<Rigidbody>();
        objectTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isForward)
        {
            if(transform.position == point.position && !isBack)
            {
                timer++;
                if(timer > 400)
                {
                    timer = 0;
                    isBack = true;
                }
            }
            else if(transform.position != point.position && !isBack)
            {
                objectTransform.position = Vector3.Lerp(objectTransform.position, point.position, speed * Time.deltaTime);
            }

            if(isBack)
            {
                objectTransform.position = Vector3.Lerp(objectTransform.position, initPos, speed * Time.deltaTime);
                if(transform.position == initPos)
                {
                    isForward = false;
                    isBack = false;
                }
            }
        }
        else
        {
            timer++;
            if (timer > 600)
            {
                timer = 0;
                isForward = true;
            }
        }
    }
}
