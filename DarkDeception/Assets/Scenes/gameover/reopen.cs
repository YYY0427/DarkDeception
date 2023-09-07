using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class reopen : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject _objText;
    public GameObject _obj;
    public TextMeshProUGUI _text;
    public static bool clickButton;

    readonly float _fadeSpeed = 1f;

    void Start()
    {
        _objText = GameObject.Find("continueText");
        _text = _objText.GetComponent<TextMeshProUGUI>();
    }
    public void OnClickStartButton()
   {
        clickButton = true;
        PlayerLife.life = 3;
        _obj.GetComponent<SceneController>().sceneChange("SceneMain");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        _text.fontSize = 36;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //_text.color = new Color(0.68f, 0.68f, 0.69f, 1.0f);
        _text.color = new Color(0.86f, 0.86f, 0.86f, 1.0f);
        _text.fontSize = 30;
    }

}
