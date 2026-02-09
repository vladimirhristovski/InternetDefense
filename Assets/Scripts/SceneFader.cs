using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class SceneFader : MonoBehaviour
{
    public Image image;
    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.unscaledDeltaTime;
            float alpha = curve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }
    }
    
    IEnumerator FadeOut(string sceneName)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.unscaledDeltaTime;
            float alpha = curve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }
        
        SceneManager.LoadScene(sceneName);
    }
    
}
