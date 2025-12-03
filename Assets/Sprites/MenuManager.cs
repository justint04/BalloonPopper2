using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject instructionsPanel;
    public GameObject settingsPanel;
    public GameObject highScoresPanel;
    
    public void StartGame()
    {
    ScoreManager.Instance.ResetGame();  
    SceneManager.LoadScene("Level1");
    }

    public void ShowInstructions()
    {
        mainMenuPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void ShowSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        instructionsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        highScoresPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ShowHighScores()
    {
        Debug.Log("ShowHighScores() CALLED");

        if (highScoresPanel == null)
            Debug.LogError("HighScoresPanel is NOT assigned in MenuManager!");

        if (mainMenuPanel == null)
            Debug.LogError("MainMenuPanel is NOT assigned in MenuManager!");

        mainMenuPanel.SetActive(false);
        highScoresPanel.SetActive(true);

        Debug.Log("HighScoresPanel active = " + highScoresPanel.activeSelf);

          UIAnimator anim = highScoresPanel.GetComponent<UIAnimator>();
        if (anim != null)
            anim.PlayShowAnimation();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game quit (works in build only).");
    }
}
