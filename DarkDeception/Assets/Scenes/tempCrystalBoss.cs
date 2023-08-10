using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tempCrystalBoss : MonoBehaviour
{
    public GameObject _objText;
    public TextMeshProUGUI _text;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        _objText = GameObject.Find("crystalNum");
        _text = _objText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count = 0;
        foreach (Transform child in this.transform)
        {
            count++;
        }
        _text.text = "remaining  " + count.ToString();
        Debug.Log(count);
    }
}
