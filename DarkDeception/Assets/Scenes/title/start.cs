using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class start : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject _objText;
    public TextMeshProUGUI _text;

    void Start()
    {
        _objText = GameObject.Find("startText");
        _text = _objText.GetComponent<TextMeshProUGUI>();
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("sceneSelectScene");
        Debug.Log("�����ꂽ");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("�}�E�X��" + gameObject.name + "�ɐG�ꂽ");
        _text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("�}�E�X��" + gameObject.name + "���痣�ꂽ");
        _text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    }
}
