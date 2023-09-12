using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class stage1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject _obj;
    public GameObject _objText;
    public TextMeshProUGUI _text;
    public GameObject _fadePrefab;

    [SerializeField]
    private GameObject loadUI;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private GameObject enemyExplanation;
    [SerializeField]
    private GameObject crystalExplanation;
    [SerializeField]
    private GameObject button;
    private Button startButton;

    void Start()
    {
        _objText = GameObject.Find("stage1Text");
        _text = _objText.GetComponent<TextMeshProUGUI>();
        startButton = button.GetComponent<Button>();
    }

    public void OnClickNextButton()
    {
        crystalExplanation.SetActive(false);
        enemyExplanation.SetActive(true);
        button.SetActive(true);
    }

    public void OnClickStartButton()
    {
        startButton.image.color = Color.black;  
        enemyExplanation.SetActive(false);

        //�@���[�h���UI���A�N�e�B�u�ɂ���
        loadUI.SetActive(true);

        //�@�R���[�`�����J�n
        StartCoroutine("LoadData");
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
    IEnumerator LoadData()
    {
        // �V�[���̓ǂݍ��݂�����
        AsyncOperation async = SceneManager.LoadSceneAsync("SceneMain");

        //�@�ǂݍ��݂��I���܂Ői���󋵂��X���C�_�[�̒l�ɔ��f������
        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
        }
    }
}
