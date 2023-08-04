using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quitTitle : MonoBehaviour
{
    public void OnClickStartButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("‰Ÿ‚³‚ê‚½");
    }
}
