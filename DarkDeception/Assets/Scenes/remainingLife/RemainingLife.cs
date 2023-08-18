using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingLife : MonoBehaviour
{

    public Canvas canvas;
    public Image image;
    public Texture2D sprite;

    // Start is called before the first frame update
    void Start()
    {

        sprite = Resources.Load<Texture2D>("temp");

        GameObject g = new GameObject();
        g.AddComponent<RectTransform>();
        g.AddComponent<Image>();

        image = g.GetComponent<Image>();
        //image.sprite = sprite;

        g.transform.SetParent(canvas.transform, false);
    }

    private void FixedUpdate()
    {
        Debug.Log(sprite);
    }

}
