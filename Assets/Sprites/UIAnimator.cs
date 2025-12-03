using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIAnimator : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public RectTransform rect;

    void Awake()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
        if (rect == null) rect = GetComponent<RectTransform>();
    }

    public void PlayShowAnimation()
    {
        StartCoroutine(ShowAnimation());
    }

    IEnumerator ShowAnimation()
    {
        canvasGroup.alpha = 0f;
        rect.localScale = Vector3.one * 0.7f;

        float t = 0f;
        const float duration = 0.25f;

        while (t < duration)
        {
            t += Time.deltaTime;

            float progress = t / duration;

            canvasGroup.alpha = progress;

            rect.localScale = Vector3.Lerp(Vector3.one * 0.7f, Vector3.one, progress);

            yield return null;
        }

        canvasGroup.alpha = 1f;
        rect.localScale = Vector3.one;
    }
}
