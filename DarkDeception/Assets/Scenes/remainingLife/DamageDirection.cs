using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageDirection : MonoBehaviour
{

    public static DamageDirection instance;

    public Image img;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        img.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime);
    }

    public virtual void Damage()
    {
        // *âÊñ Çê‘ìhÇËÇ…Ç∑ÇÈ
        this.img.color = new Color(0.5f, 0f, 0f, 0.5f);
    }

}
