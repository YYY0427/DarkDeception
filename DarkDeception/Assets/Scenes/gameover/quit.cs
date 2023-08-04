using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quit : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("titleScene");
        Debug.Log("‰Ÿ‚³‚ê‚½");
    }
}
