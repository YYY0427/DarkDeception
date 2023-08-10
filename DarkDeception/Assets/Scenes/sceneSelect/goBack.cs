using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class goBack : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject _objText;
    public TextMeshProUGUI _text;
    public GameObject _fadePrefab;

    readonly float _fadeSpeed = 1f;

    void Start()
    {
        _objText = GameObject.Find("goBackText");
        _text = _objText.GetComponent<TextMeshProUGUI>();
    }

    public void OnClickStartButton()
    {
        StartCoroutine(nameof(LoadScene));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    }

    IEnumerator LoadScene()
    {
        Instantiate(_fadePrefab);
        yield return new WaitForSeconds(_fadeSpeed);
        SceneManager.LoadScene("titleScene");
    }

}
