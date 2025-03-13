using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet prefab
    public Transform shootingOffset; // Where bullets spawn
    public float speed = 5f; // Player movement speed
    public float screenLimit = 7.5f; // Movement boundary
    public AudioSource shootSound; // Shooting sound reference

    void Start()
    {
        shootSound = GetComponent<AudioSource>(); // Get the Audio Source
    }

    void Update()
    {
        // Move left & right
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.position += new Vector3(move, 0, 0);

        // Keep player inside screen bounds
        float clampedX = Mathf.Clamp(transform.position.x, -screenLimit, screenLimit);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        // Shoot bullets
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shot = Instantiate(bulletPrefab, shootingOffset.position, Quaternion.identity);
            shootSound.Play(); // Play shooting sound
            Debug.Log("Bang!");
            Destroy(shot, 3f); // Destroy bullet after 3 seconds
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet")) // Enemy bullet kills player
        {
            Debug.Log("Player Died!");
            ExplodeAndGameOver();
        }
    }

    void ExplodeAndGameOver()
    {
        Debug.Log("Player Destroyed!");
        Destroy(gameObject); // Destroy player
        FindObjectOfType<GameManager>().GameOver(); // Call Game Over
    }
}
