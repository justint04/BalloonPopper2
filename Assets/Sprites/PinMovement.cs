using UnityEngine;

public class PinMovement : MonoBehaviour
{
    public GameObject floatingScorePrefab;   
    public float speed = 10f;
    public AudioClip popSound;
    public float popVolume = 1f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (transform.position.y > Camera.main.orthographicSize + 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Balloon"))
        {
            if (popSound != null)
                AudioSource.PlayClipAtPoint(popSound, transform.position, popVolume);

            float sx = collision.transform.localScale.x;
            float sy = collision.transform.localScale.y;
            float avgScale = (sx + sy) * 0.5f;

            float basePoints = 25f;
            int points = Mathf.RoundToInt(avgScale * basePoints);

            if (floatingScorePrefab != null)
            {
                Canvas canvas = FindObjectOfType<Canvas>();
                if (canvas != null)
                {
                    GameObject fsObj = Instantiate(floatingScorePrefab, canvas.transform);

                    FloatingScore fs = fsObj.GetComponent<FloatingScore>();
                    if (fs != null)
                        fs.Show(points, collision.transform.position);
                }
                else
                {
                    Debug.LogWarning("PinMovement: No Canvas found for floating score.");
                }
            }

            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddScore(points);
            else
                Debug.LogWarning("PinMovement: ScoreManager.Instance is null — score not added.");

            if (LevelManager.Instance != null)
                LevelManager.Instance.LoadNextLevel();

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Bird"))
        {
            Destroy(gameObject);
        }
    }
}
