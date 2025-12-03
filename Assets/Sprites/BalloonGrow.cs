using UnityEngine;

public class BalloonGrow : MonoBehaviour 
{
    public float growAmount = 0.1f;
    public float growInterval = 1f;
    public float maxScale = 3f;
    public AudioClip popSound;
    public float popVolume = 1f;
    public float growSpeed = 1.0f;

    
void Start() 
{
    InvokeRepeating("Grow", 0f, growInterval);
    int diff = PlayerPrefs.GetInt("GameDifficulty", 0);
    if (diff == 0) growSpeed = 1.0f; 
    if (diff == 1) growSpeed = 1.5f; 
    if (diff == 2) growSpeed = 2.0f; 
    }

void Grow() 
{ 
    transform.localScale += new Vector3(growAmount, growAmount, 0f);
    if (transform.localScale.x >= maxScale) {
        if (popSound != null) 
        AudioSource.PlayClipAtPoint(popSound, transform.position, popVolume);
        CancelInvoke("Grow");
        Destroy(gameObject);
        if (LevelManager.Instance != null)
        LevelManager.Instance.RestartLevel();
    }
}
}
