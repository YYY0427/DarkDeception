using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class quitTitle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject _objText;
    public TextMeshProUGUI _text;
    void Start()
    {
        _objText = GameObject.Find("quitText");
        _text = _objText.GetComponent<TextMeshProUGUI>();

    }

    public void OnClickStartButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    }
}
