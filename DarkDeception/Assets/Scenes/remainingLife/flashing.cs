using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashing : MonoBehaviour
{

    public static flashing instance;

    Behaviour target;
    GameObject lastImage;

    private float cycle = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void flachingUpdate()
    {
        lastImage = ImageScript.lastImage;

        var repeatValue = Mathf.Repeat(ImageScript.coutTime, cycle);

        target = lastImage.GetComponent<Image>();

        target.enabled = repeatValue >= cycle * 0.5f;
    }
}
