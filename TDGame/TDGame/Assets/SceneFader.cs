using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{

    public Image image;
    public AnimationCurve curve;

    private void Start()
    {

        StartCoroutine(nameof(FadeIn));
    }

    public void FadeTo(int scene)
    {
        StartCoroutine(FadeOut(scene));
    }


    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime * 0.5f;
            float a = curve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

    }

    IEnumerator FadeOut(int scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 0.5f;
            float a = curve.Evaluate(t);
            image.color = new Color(0f,0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }

}
