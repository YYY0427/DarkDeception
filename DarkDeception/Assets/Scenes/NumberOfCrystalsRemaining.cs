using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NumberOfCrystalsRemaining : MonoBehaviour
{
    public GameObject _objText;
    public TextMeshProUGUI _text;
    public GameObject _crystal;
    public GameObject _fade;
    GameObject _singletonObj;

    int count = 0;
    int fadeCount = 1;
    readonly float _fadeSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _crystal = GameObject.Find("tempCrystal");
        _objText = GameObject.Find("crystalNum");
        _singletonObj = GameObject.Find("Singleton");
        _text = _objText.GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        count = 0;
        if(SingletonScript.instance != null)
        {
            foreach (Transform child in _crystal.transform)
            {
                count++;
            }
        }
        
        _text.text = "" + count.ToString();

        if(count == 0 && fadeCount > 0)
        {
            fadeCount = 0;
            PlayerLife.life = 3;
            SingletonScript.instance = null;
            Destroy(_singletonObj);
            _fade.GetComponent<SceneController>().sceneChange("clearScene");
        }

    }
}
