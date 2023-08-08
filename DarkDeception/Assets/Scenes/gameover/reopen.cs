using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class reopen : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject _objText;
    public TextMeshProUGUI _text;
    void Start()
    {
        _objText = GameObject.Find("reopenText");
        _text = _objText.GetComponent<TextMeshProUGUI>();
    }
    public void OnClickStartButton()
   {
        SceneManager.LoadScene("mainScene");
        Debug.Log("押された");
   }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("マウスが" + gameObject.name + "に触れた");
        _text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("マウスが" + gameObject.name + "から離れた");
        _text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    }

}
