using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScript : MonoBehaviour
{
    private GameObject obj;
    private int spriteX = new int();
    // Start is called before the first frame update
    void Start()
    {
        obj = (GameObject)Resources.Load("Sprite 1");

        spriteX = 320;
        for (int i = PlayerLife.life; i > 0; i--)
        {
            Instantiate(obj, new Vector3(spriteX, 190, 0), Quaternion.AngleAxis(-90.0f,new Vector3(1.0f,0.0f,0.0f)));
            spriteX += 100;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(PlayerLife.life);
    }

}
