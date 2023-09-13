using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class start : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject _fade;
    public GameObject _objText;
    public TextMeshProUGUI _text;
    public GameObject _fadePrefab;
    public AudioSource _audioSource;

    readonly float _fadeSpeed = 1f;

    void Start()
    {
        _objText = GameObject.Find("startText");
        _text = _objText.GetComponent<TextMeshProUGUI>();
        // AudioSourceコンポーネントの取得
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnClickStartButton()
    {
        // 音源の再生
        _audioSource.Play();
        _fade.GetComponent<SceneController>().sceneChange("sceneSelectScene");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("通ってる");
        _text.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
}
