using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class remainingLifeContinue : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject _objText;
    public TextMeshProUGUI _text;
    public GameObject _fadePrefab;

    readonly float _fadeSpeed = 1f;

    void Start()
    {
        _objText = GameObject.Find("continueText");
        _text = _objText.GetComponent<TextMeshProUGUI>();
    }
    public void OnClickStartButton()
    {
        StartCoroutine(nameof(LoadScene));
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

    IEnumerator LoadScene()
    {
        Instantiate(_fadePrefab);
        yield return new WaitForSeconds(_fadeSpeed);
        SceneManager.LoadScene("SceneMain");
    }
}
