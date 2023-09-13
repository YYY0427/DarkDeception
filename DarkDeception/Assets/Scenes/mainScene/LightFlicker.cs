using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LightFlicker : MonoBehaviour
{
    public Light targetLight;           // �_�ł����郉�C�g
    public float minIntensity = 0.0f;   // �ŏ��̖��邳
    public float maxIntensity = 1.0f;   // �ő�̖��邳
    public float flickerSpeed = 0.3f;   // �_�ł̑���

    private float originalIntensity;

    void Start()
    {
        if (targetLight != null)
        {
            originalIntensity = targetLight.intensity;
            // �R���[�`�����J�n���ē_�Ō��ʂ����s
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