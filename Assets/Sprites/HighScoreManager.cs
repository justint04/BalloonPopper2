using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;

    public int maxScores = 5; 
    private List<int> highScores = new List<int>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadScores();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int newScore)
    {
        highScores.Add(newScore);
        highScores.Sort((a, b) => b.CompareTo(a)); 

        if (highScores.Count > maxScores)
            highScores.RemoveAt(highScores.Count - 1);

        SaveScores();
    }

    public List<int> GetScores()
    {
        return new List<int>(highScores);
    }

    private void SaveScores()
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, highScores[i]);
        }

        PlayerPrefs.SetInt("HighScoreCount", highScores.Count);
        PlayerPrefs.Save();
    }

    private void LoadScores()
    {
        highScores.Clear();

        int count = PlayerPrefs.GetInt("HighScoreCount", 0);

        for (int i = 0; i < count; i++)
        {
            int score = PlayerPrefs.GetInt("HighScore" + i, 0);
            highScores.Add(score);
        }
        
        highScores.Sort((a, b) => b.CompareTo(a));
    }
}
