using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyBulletPrefab; // Bullet prefab for shooting
    public Transform firePoint; // Where bullets spawn
    public GameObject explosionPrefab; // Explosion effect
    public AudioSource enemyShootSound; // Shooting sound
    public AudioSource explosionSound; // Explosion sound

    public float speed = 2f; // Sideways movement speed
    public float moveDownAmount = 0.5f; // Distance enemies move down
    public float fireRate = 2f; // Time between shots
    public float screenBoundary = 7.5f; // Screen limit
    private float nextFireTime; 
    private int direction = 1; // 1 = Right, -1 = Left

    void Start()
    {
        enemyShootSound = GetComponent<AudioSource>(); // Get shooting sound
    }

    void Update()
    {
        // Move enemy side to side
        transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);

        // If enemy reaches boundary, move down and change direction
        if (transform.position.x > screenBoundary || transform.position.x < -screenBoundary)
        {
            MoveDownAndReverse();
        }

        // Enemy Shooting Logic
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate + Random.Range(-0.5f, 0.5f); // Add randomness
        }
    }

    void MoveDownAndReverse()
    {
        direction *= -1; // Reverse movement direction
        transform.position += new Vector3(0, -moveDownAmount, 0); // Move enemies down
        speed += 0.2f; // Speed up enemies slightly over time
    }

    void Shoot()
    {
        if (enemyBulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(enemyBulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb == null)
            {
                rb = bullet.AddComponent<Rigidbody2D>(); 
            }

            rb.linearVelocity = new Vector2(0, -5f); // Make bullets go downward
            bullet.tag = "EnemyBullet"; 

            if (enemyShootSound != null)
            {
                enemyShootSound.Play(); // Play shooting sound
            }

            Destroy(bullet, 5f); // Destroy after 5 sec
            Debug.Log("Enemy Fires!");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")) // Check for bullet hit
        {
            Debug.Log("Enemy Hit!");
            Destroy(collision.gameObject); // Destroy bullet

            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            if (explosionSound != null)
            {
                explosionSound.Play(); // Play explosion sound
            }

            Destroy(gameObject); // Destroy enemy
            FindObjectOfType<GameManager>().AddScore(10);
        }
    }
}
