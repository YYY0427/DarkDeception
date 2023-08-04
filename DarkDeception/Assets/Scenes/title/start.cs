using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("sceneSelectScene");
        Debug.Log("‰Ÿ‚³‚ê‚½");
    }
}
