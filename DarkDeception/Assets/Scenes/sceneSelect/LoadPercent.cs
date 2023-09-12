using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadPercent : MonoBehaviour
{
    private TextMeshProUGUI cardNameText;

    [SerializeField]
    private Slider slider;
    private void Start()
    {
        cardNameText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        cardNameText.SetText("{0}%", slider.value * 100.0f);
    }
}
