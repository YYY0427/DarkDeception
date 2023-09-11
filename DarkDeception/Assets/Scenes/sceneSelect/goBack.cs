using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class goBack : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject _obj;
    public GameObject _objText;
    public TextMeshProUGUI _text;
    public AudioSource _audioSource;

    readonly float _fadeSpeed = 1f;

    void Start()
    {
        _objText = GameObject.Find("goBackText");
        _text = _objText.GetComponent<TextMeshProUGUI>();
        // AudioSourceのコンポーネント取得
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnClickStartButton()
    {
        // 音楽再生
        _audioSource.Play();
        _obj.GetComponent<SceneController>().sceneChange("titleScene");
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
