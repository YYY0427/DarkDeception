using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LightFlicker : MonoBehaviour
{
    public Light targetLight;           // 点滅させるライト
    public float minIntensity = 0.0f;   // 最小の明るさ
    public float maxIntensity = 1.0f;   // 最大の明るさ
    public float flickerSpeed = 0.3f;   // 点滅の速さ

    private float originalIntensity;

    void Start()
    {
        if (targetLight != null)
        {
            originalIntensity = targetLight.intensity;
            // コルーチンを開始して点滅効果を実行
            StartCoroutine(Flicker());
        }
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            float randomIntensity = Random.Range(minIntensity, maxIntensity);
            targetLight.intensity = randomIntensity;
            yield return new WaitForSeconds(1 / flickerSpeed);
            targetLight.intensity = originalIntensity;
            yield return new WaitForSeconds(1 / flickerSpeed);
        }
    }
}