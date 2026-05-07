using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PointsManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    [SerializeField] RawImage imagePoints100;
    [SerializeField] RawImage imagePoints150;

    float duration = 0.5f;

    int score;

    private void Update()
    {
        scoreText.text = score.ToString();
    }

    public int AddPoints()
    {
        StartCoroutine(PopUp(imagePoints100));
        return score += 100;
    }

    public int AddMorePoints()
    {
        StartCoroutine(PopUp(imagePoints150));
        return score += 150;
    }

    IEnumerator PopUp(RawImage image)
    {
        StartCoroutine(Fade(0, 1, image));
        yield return new WaitForSeconds(1);
        StartCoroutine(Fade(1, 0, image));
    }

    IEnumerator Fade(float inicio, float fin, RawImage imagen)
    {
        float tiempo = 0f;

        Color c = imagen.color;
        c.a = inicio;
        imagen.color = c;

        while (tiempo < duration)
        {
            tiempo += Time.deltaTime;

            float alpha = Mathf.Lerp(inicio, fin, tiempo / duration);

            c.a = alpha;
            imagen.color = c;

            yield return null;
        }

        c.a = fin;
        imagen.color = c;
    }
}
