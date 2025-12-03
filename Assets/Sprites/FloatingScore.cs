using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloatingScore : MonoBehaviour
{
    public Text scoreText;
    public CanvasGroup canvasGroup;
    public float floatDistance = 50f;
    public float duration = 0.6f;

    Vector3 startPos;

    void Awake()
    {
        if (scoreText == null) scoreText = GetComponent<Text>();
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show(int points, Vector3 worldPosition)
    {
        scoreText.text = "+" + points;

        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);
        transform.position = screenPos;

        startPos = transform.position;

        StartCoroutine(PlayFloating());
    }

    IEnumerator PlayFloating()
    {
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float progress = t / duration;

            transform.position = startPos + Vector3.up * floatDistance * progress;

            canvasGroup.alpha = 1f - progress;

            yield return null;
        }

        Destroy(gameObject);
    }
}
