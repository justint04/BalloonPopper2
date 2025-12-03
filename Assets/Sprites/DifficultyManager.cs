using UnityEngine;
using TMPro;

public class DifficultyManager : MonoBehaviour
{
    public TMP_Dropdown difficultyDropdown;

    void Start()
    {
        int savedDifficulty = PlayerPrefs.GetInt("GameDifficulty", 0);
        difficultyDropdown.value = savedDifficulty;
        difficultyDropdown.onValueChanged.AddListener(OnDifficultyChanged);
    }

    void OnDifficultyChanged(int index)
{
    PlayerPrefs.SetInt("GameDifficulty", index);
    
    DifficultyDisplay display = FindObjectOfType<DifficultyDisplay>();
    if (display != null)
    {
        display.UpdateDifficultyUI();
    }
    
    switch (index)
    {
        case 0: 
            Debug.Log("Difficulty: Easy");
            break;
        case 1: 
            Debug.Log("Difficulty: Medium");
            break;
        case 2: 
            Debug.Log("Difficulty: Hard");
            break;
    }
}
}

