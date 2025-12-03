using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float speed = 3f;
    public Vector2 moveDirection = Vector2.right; // default to moving right
    public float offscreenDistance = 12f;

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Destroy bird if it goes too far off screen
        if (Mathf.Abs(transform.position.x) > offscreenDistance)
        {
            Destroy(gameObject);
        }
    }
}