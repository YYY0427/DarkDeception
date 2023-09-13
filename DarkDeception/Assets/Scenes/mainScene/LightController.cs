using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light[] lights; // 子ライトオブジェクトの配列

    public Light[] targetLight;           // 点滅させるライト
    public float minIntensity = 0.0f;   // 最小の明るさ
    public float maxIntensity = 0.5f;   // 最大の明るさ
    public float flickerSpeed = 0.5f;   // 点滅の速さ

    private float originalIntensity;

    public void Start()
    {
        // ライトオブジェクトをすべて取得
        lights = GetComponentsInChildren<Light>();

        for(int i = 0; i < 15; i++)
        {
            targetLight[i] = lights[i];
        }

        if (lights != null)
        {
            for (int i = 0; i < 15; i++)
            {
                originalIntensity = targetLight[i].intensity;
            }
            // コルーチンを開始して点滅効果を実行
            StartCoroutine(Flicker());
        }
    }
    IEnumerator Flicker()
    {
        while (true)
        {
            float randomIntensity = Random.Range(minIntensity, maxIntensity);
            for(int i = 0; i < 15; i++)
            {
                targetLight[i].intensity = randomIntensity;
            }
            yield return new WaitForSeconds(1 / flickerSpeed);
            for(int i = 0; i < 15; i++)
            {
                targetLight[i].intensity = originalIntensity;
            }
            yield return new WaitForSeconds(1 / flickerSpeed);
        }
    }
}
