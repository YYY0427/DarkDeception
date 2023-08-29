using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScript : MonoBehaviour
{
    GameObject canvas;
    public static GameObject lastImage;
    public Sprite bone;

    private Vector3 setImagePotion;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        setImagePotion.x = 916 / 2 - 120;
        setImagePotion.y = 515 / 2 - 30;

        for(int i = PlayerLife.life + 1; i > 0; i--)
        {
            GameObject image = new GameObject();
            image.AddComponent<RectTransform>();
            image.AddComponent<Image>();

            Image image1 =  image.GetComponent<Image>();
            image1.sprite = bone;

            image.transform.SetParent(canvas.transform, false);

            image.transform.position = setImagePotion;

            setImagePotion.x += 120;

            lastImage = image;

        }

    }

    private float time;
    public static float coutTime;

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        coutTime = time;

        if(time <= 4.0f)
        {
            flashing.instance.flachingUpdate();
        }
        else if(lastImage != null)
        {
            Destroy(lastImage);
        }
    }
}
