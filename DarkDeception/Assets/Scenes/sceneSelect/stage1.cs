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
    //　読み込み率を表示するスライダー
    [SerializeField]
    private Slider slider;
    public AudioSource _audioSource;


    readonly float _fadeSpeed = 1f;

    void Start()
    {
        _objText = GameObject.Find("stage1Text");
        _text = _objText.GetComponent<TextMeshProUGUI>();
        // AudioSourceのコンポーネント取得
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnClickStartButton()
    {
        //    _obj.GetComponent<SceneController>().sceneChange("SceneMain");

        // 音楽再生
        _audioSource.Play();

        //　ロード画面UIをアクティブにする
        loadUI.SetActive(true);

        //　コルーチンを開始
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
        // シーンの読み込みをする
        AsyncOperation async = SceneManager.LoadSceneAsync("SceneMain");

        //　読み込みが終わるまで進捗状況をスライダーの値に反映させる
        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
            //slider.value = async.progress;
            //if (async.progress >= 0.9f)
            //{
            //    async.allowSceneActivation = true;
            //}
            //yield return null;
        }
    }
}
