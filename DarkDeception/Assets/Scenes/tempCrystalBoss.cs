using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tempCrystalBoss : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count = 0;
        foreach (Transform child in _crystal.transform)
        {
            count++;
        }
        _text.text = "remaining  " + count.ToString();
    }
}
