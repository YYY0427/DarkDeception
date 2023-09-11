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
    public AudioSource _cancellationSound;
    void Start()
    {
        _objText = GameObject.Find("quitText");
        _text = _objText.GetComponent<TextMeshProUGUI>();

    }

    public void OnClickStartButton()
    {
        _cancellationSound.Play();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        _text.fontSize = 36;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _text.color = new Color(0.68f, 0.68f, 0.69f, 1.0f);
        _text.fontSize = 24;
    }
}
