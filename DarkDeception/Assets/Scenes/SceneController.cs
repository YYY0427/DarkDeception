using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public GameObject fade;
    public GameObject fadeCanvas;

    // Start is called before the first frame update
    void Start()
    {
        if (!FadeManager.isFadeInstance)
        {
            Instantiate(fade);
        }
        Invoke("findFadeObject", 0.02f);
    }

    void findFadeObject()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("fade");
        fadeCanvas.GetComponent<FadeManager>().fadeIn();
    }

    public async void sceneChange(string sceneName)
    {
        fadeCanvas.GetComponent<FadeManager>().fadeOut();
        await Task.Delay(200);
        SceneManager.LoadScene(sceneName);
    }
}