using UnityEngine;
using UnityEngine.UI;

public class DifficultyDisplay : MonoBehaviour
{
    public Text difficultyText; // assign in Inspector

    void Start()
    {
        UpdateDifficultyUI();
    }

    // Make sure this method is public so other scripts can call it
    public void UpdateDifficultyUI()
    {
        int diff = PlayerPrefs.GetInt("GameDifficulty", 0);

        string label;
        switch (diff)
        {
            case 0: label = "Difficulty: Easy"; break;
            case 1: label = "Difficulty: Medium"; break;
            case 2: label = "Difficulty: Hard"; break;
            default: label = "Difficulty: Unknown"; break;
        }

        if (difficultyText != null)
            difficultyText.text = label;
        else
            Debug.LogWarning("DifficultyDisplay: difficultyText not assigned in Inspector.");
    }
}
