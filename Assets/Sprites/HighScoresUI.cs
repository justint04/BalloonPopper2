using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HighScoresUI : MonoBehaviour
{
    public Text[] scoreTexts; 

    void OnEnable()
    {
        RefreshScores();
    }

    public void RefreshScores()
    {
        List<int> scores = HighScoreManager.Instance.GetScores();

        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < scores.Count)
                scoreTexts[i].text = (i + 1) + ". " + scores[i];
            else
                scoreTexts[i].text = (i + 1) + ". ---";
        }
    }

    public void BackToMenu()
    {
        gameObject.SetActive(false);
    }
}
