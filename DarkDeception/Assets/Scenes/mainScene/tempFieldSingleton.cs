using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempFieldSingleton : MonoBehaviour
{
    public static tempFieldSingleton instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
