using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject pinPrefab;   
    public Transform shootPoint;   
    public AudioClip shootSound;
    public float shootVolume = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ShootPin();
        }
    }

    void ShootPin()
    {
        Transform spawnPos = shootPoint != null ? shootPoint : transform;
        GameObject pin = Instantiate(pinPrefab, spawnPos.position, Quaternion.identity);

        if (shootSound != null)
            AudioSource.PlayClipAtPoint(shootSound, transform.position, shootVolume);
    }
}
