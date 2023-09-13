using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light[] lights; // �q���C�g�I�u�W�F�N�g�̔z��

    public Light[] targetLight;           // �_�ł����郉�C�g
    public float minIntensity = 0.0f;   // �ŏ��̖��邳
    public float maxIntensity = 0.5f;   // �ő�̖��邳
    public float flickerSpeed = 0.5f;   // �_�ł̑���

    private float originalIntensity;

    public void Start()
    {
        // ���C�g�I�u�W�F�N�g�����ׂĎ擾
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
            // �R���[�`�����J�n���ē_�Ō��ʂ����s
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
