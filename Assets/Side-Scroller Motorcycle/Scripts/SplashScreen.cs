using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    public Slider loadingSlider;
    public float loadingTime = 3f;

    private void Start()
    {
        StartCoroutine(Loading());
    }

    private IEnumerator Loading()
    {
        float progress = 0f;

        while (progress < loadingTime)
        {
            progress += Time.deltaTime;
            loadingSlider.value = progress / loadingTime;
            yield return null;
        }

        Application.LoadLevel("Main_Menu");
        // Do something after the loading is complete, such as loading the next scene or enabling the game controls.
    }
}
