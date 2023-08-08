using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    readonly float waitTime = 1f;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        StartCoroutine(nameof(Transition));
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(waitTime);

        Destroy(gameObject);
    }

}
