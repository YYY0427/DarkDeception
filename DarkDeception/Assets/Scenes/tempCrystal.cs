using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempCrystal : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("hit");
            Destroy(this.gameObject);
        }
    }

}
