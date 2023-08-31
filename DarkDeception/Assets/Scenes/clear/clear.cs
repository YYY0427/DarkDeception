using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class clear : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject _objText;
    public TextMeshProUGUI _text;
    public GameObject _fadePrefab;

    readonly float _fadeSpeed = 1f;

    void Start()
    {
        _objText = GameObject.Find("TitleText");
        _text = _objText.GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        _text.fontSize = 36;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _text.color = new Color(0.86f, 0.86f, 0.86f, 1.0f);
        _text.fontSize = 30;
    }

    public void OnClickStartButton()
    {
        StartCoroutine(nameof(LoadScene));
    }

    IEnumerator LoadScene()
    {
        Instantiate(_fadePrefab);
        yield return new WaitForSeconds(_fadeSpeed);
        SceneManager.LoadScene("titleScene");
    }
}
