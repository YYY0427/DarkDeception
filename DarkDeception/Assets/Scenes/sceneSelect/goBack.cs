using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class GoBack : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject _obj;
    public GameObject _objText;
    public TextMeshProUGUI _text;

    [SerializeField]
    private GameObject crystalExplanation;

    [SerializeField]
    private GameObject enemyExplanation;

    [SerializeField]
    private GameObject startButton;

    void Start()
    {
        _objText = GameObject.Find("goBackText");
        _text = _objText.GetComponent<TextMeshProUGUI>();
    }
    public void OnClickBackGameExplanation1()
    {
        startButton.SetActive(false);
        enemyExplanation.SetActive(false);
        crystalExplanation.SetActive(true);
    }
    public void OnClickStartButton()
    {
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
