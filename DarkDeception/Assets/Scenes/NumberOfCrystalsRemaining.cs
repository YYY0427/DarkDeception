using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NumberOfCrystalsRemaining : MonoBehaviour
{
    public GameObject _objText;
    public TextMeshProUGUI _text;
    public GameObject _crystal;
    public GameObject _fadePrefab;

    int count = 0;
    readonly float _fadeSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _crystal = GameObject.Find("tempCrystal");
        _objText = GameObject.Find("crystalNum");
        _text = _objText.GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        count = 0;
        foreach (Transform child in _crystal.transform)
        {
            count++;
        }
        _text.text = "remaining  " + count.ToString();

        if(count <= 0)
        {
            StartCoroutine(nameof(LoadScene));
        }
    }

    IEnumerator LoadScene()
    {
        Instantiate(_fadePrefab);
        yield return new WaitForSeconds(_fadeSpeed);
        SceneManager.LoadScene("clearScene");
    }

}
