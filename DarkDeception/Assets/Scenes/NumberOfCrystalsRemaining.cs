using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberOfCrystalsRemaining : MonoBehaviour
{
    public GameObject _objText;
    public TextMeshProUGUI _text;
    public GameObject _crystal;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        _crystal = GameObject.Find("tempCrystal");
        _objText = GameObject.Find("crystalNum");
        _text = _objText.GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        count = 0;
        foreach (Transform child in _crystal.transform)
        {
            count++;
        }
        _text.text = "remaining  " + count.ToString();
    }
}
