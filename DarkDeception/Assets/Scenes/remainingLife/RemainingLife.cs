using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingLife : MonoBehaviour
{

    public Canvas canvas;
    public Image image;
    private Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {

        sprite = Resources.Load<Sprite>("temp");

        GameObject g = new GameObject();
        g.AddComponent<RectTransform>();
        g.AddComponent<Image>();

        image = g.GetComponent<Image>();
        image.sprite = sprite;

        g.transform.SetParent(canvas.transform, false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(PlayerLife.life);
    }
}
