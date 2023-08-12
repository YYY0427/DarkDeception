using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainingLife : MonoBehaviour
{
    MovePlayer _script;

    // Start is called before the first frame update
    void Start()
    {
        _script = GameObject.Find("Player").GetComponent<MovePlayer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(_script.life);
    }
}
