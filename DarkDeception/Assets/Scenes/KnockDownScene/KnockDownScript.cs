using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnockDownScript : MonoBehaviour
{
    private int _nextSceneFrame;    // Ÿ‚ÌƒV[ƒ“‚ÉˆÚs‚·‚é‚Ü‚Å‚ÌŠÔ
    void Start()
    {
        _nextSceneFrame = 150;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _nextSceneFrame--;

        if (_nextSceneFrame < 0)
        {
            PlayerLife.changeScene();
        }
    }
}
