using System.Collections; 
using UnityEngine; 
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{ 
    public static LevelManager Instance; 
    void Awake() 
    {
        if (Instance == null) 
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject); 
            SceneManager.sceneLoaded += OnSceneLoaded; 
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(DelayedDifficultyUpdate());
    }

    private IEnumerator DelayedDifficultyUpdate()
    {
        yield return null; 

        DifficultyDisplay display = FindAnyObjectByType<DifficultyDisplay>();
        if (display != null) 
        display.UpdateDifficultyUI();
        else
        Debug.LogWarning("No DifficultyDisplay found in scene: " + SceneManager.GetActiveScene().name);
        
    }

public void LoadNextLevel()
{
    int current = SceneManager.GetActiveScene().buildIndex;
    int total = SceneManager.sceneCountInBuildSettings;

    if (current == total - 1)
    {
        if (ScoreManager.Instance != null && HighScoreManager.Instance != null)
        {
            int finalScore = ScoreManager.Instance.GetScore();
            HighScoreManager.Instance.AddScore(finalScore);
            Debug.Log("Saved final score: " + finalScore);
        }
            SceneManager.LoadScene("MainMenu");     
            return;
    }

    SceneManager.LoadScene(current + 1);
}            
        public void RestartLevel()
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex; 
            SceneManager.LoadScene(currentIndex);
        }

}
