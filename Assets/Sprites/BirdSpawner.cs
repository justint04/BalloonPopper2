using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public float spawnInterval = 3f;
    public float spawnHeightMin = -1f;
    public float spawnHeightMax = 4f;

    void Start()
    {
        InvokeRepeating("SpawnBird", 2f, spawnInterval);
    }

    void SpawnBird()
    {
        if (birdPrefab == null) return;

        // Randomize spawn height
        float y = Random.Range(spawnHeightMin, spawnHeightMax);

        // Randomize side (left or right)
        bool fromLeft = Random.value > 0.5f;
        float x = fromLeft ? -10f : 10f;

        GameObject bird = Instantiate(birdPrefab, new Vector3(x, y, 0f), Quaternion.identity);

        // Set flying direction
        BirdMovement bm = bird.GetComponent<BirdMovement>();
        if (bm != null)
        {
            bm.moveDirection = fromLeft ? Vector2.right : Vector2.left;
        }
    }
}
