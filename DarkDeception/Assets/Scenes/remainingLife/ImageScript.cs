using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageScript : MonoBehaviour
{
    public GameObject _obj;
    GameObject canvas;
    public static GameObject lastImage;
    public Sprite bone;
    public GameObject _fadePrefab;

    readonly float _fadeSpeed = 1f;

    private Vector3 setImagePotion;

    int count = 1;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        setImagePotion.x = 916 / 2 - 116.5f;
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
    public static float countTime;

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        countTime = time;

        if (time <= 2.0f)
        {
            //flashing.instance.flachingUpdate();
        }
        else if(lastImage != null)
        {
            DamageDirection.instance.Damage();
            SE.Instance.daggerSound();
            Destroy(lastImage);
        }

        if(lastImage == null)
        {
            if (DamageDirection.instance.alpha() < 0.05)
            {
                _obj.GetComponent<SceneController>().sceneChange("SceneMain");
            }
            Debug.Log(DamageDirection.instance.alpha());
        }
        

    }

}
