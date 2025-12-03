using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    [Header("Score UI")]
    public Text scoreText; 
    
    private int score = 0;
    private int balloonsPopped = 0;
    
    [Header("Difficulty Settings")]
    public int balloonsForMedium = 1;
    public int balloonsForHard = 2;

    
    private DifficultyDisplay difficultyDisplay;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindUIElements();
    }
    
  private bool initialized = false;

    void Start()
    {
        if (initialized) return;
        initialized = true;

        score = 0;
        balloonsPopped = 0;

        PlayerPrefs.SetInt("CurrentScore", 0);
        PlayerPrefs.SetInt("BalloonsPopped", 0);
        PlayerPrefs.SetInt("GameDifficulty", 0); 
        PlayerPrefs.Save();

        FindUIElements();
    }

    
    void FindUIElements()
    {
        GameObject scoreTextObj = GameObject.Find("ScoreText"); 
        if (scoreTextObj != null)
        {
            scoreText = scoreTextObj.GetComponent<Text>();
        }
        else
        {
            scoreText = null;
            return; 
        }
        
        difficultyDisplay = FindObjectOfType<DifficultyDisplay>();
        
        UpdateScoreUI();
    }
    
    public void AddScore(int points)
    {
        score += points;
        balloonsPopped++;
        
        PlayerPrefs.SetInt("CurrentScore", score);
        PlayerPrefs.SetInt("BalloonsPopped", balloonsPopped);
        PlayerPrefs.Save();
        
        UpdateScoreUI();
        difficultyDisplay.UpdateDifficultyUI();
        
        Debug.Log("Score: " + score + ", Balloons Popped: " + balloonsPopped);
    }
    
    void UpdateScoreUI()
    {
        Debug.Log("UpdateScoreUI - scoreText is: " + (scoreText != null ? "assigned" : "NULL") + ", score = " + score);
        
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
            Debug.Log("Set score text to: Score: " + score);
        }
        else
        {
            Debug.LogWarning("Score Text is NULL! Trying to find it again...");
            FindUIElements();
        }
    }
    
    void UpdateDifficulty()
    {
        int newDifficulty = 0;
        
        if (balloonsPopped >= balloonsForHard)
            newDifficulty = 2;
        else if (balloonsPopped >= balloonsForMedium)
            newDifficulty = 1;
        else
            newDifficulty = 0;
        
        int currentDifficulty = PlayerPrefs.GetInt("GameDifficulty", 0);
        
        if (newDifficulty != currentDifficulty)
        {
            PlayerPrefs.SetInt("GameDifficulty", newDifficulty);
            PlayerPrefs.Save();
            
              if (difficultyDisplay == null)
            {
                difficultyDisplay = FindObjectOfType<DifficultyDisplay>();
            }
                

            if (difficultyDisplay != null)
            {
                difficultyDisplay.UpdateDifficultyUI();
            }
            else
            {
                Debug.LogWarning("UpdateDifficulty: no DifficultyDisplay found in scene to update now.");

            }
            
            Debug.Log("Difficulty changed to: " + GetDifficultyName(newDifficulty));
        }
    }
    
    string GetDifficultyName(int difficulty)
    {
        switch (difficulty)
        {
            case 0: return "Easy";
            case 1: return "Medium";
            case 2: return "Hard";
            default: return "Unknown";
        }
    }
    
    public int GetScore()
    {
        return score;
    }
    
    public void ResetGame()
    {
        score = 0;
        balloonsPopped = 0;
        PlayerPrefs.SetInt("CurrentScore", 0);
        PlayerPrefs.SetInt("BalloonsPopped", 0);
        PlayerPrefs.SetInt("GameDifficulty", 0);
        PlayerPrefs.Save();
        UpdateScoreUI();
    }
}