using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    int score;

    private void Update()
    {
        scoreText.text = score.ToString();
    }

    public int AddPoints()
    {
        return score += 100;
    }

    public int AddMorePoints()
    {
        return score += 150;
    }
}
