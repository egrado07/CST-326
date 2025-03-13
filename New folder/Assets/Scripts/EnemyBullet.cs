using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f; // Speed of enemy bullets

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, -speed); //  Moves bullet downward
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // If hits player
        {
            Debug.Log("Player Hit!");
            FindObjectOfType<GameManager>().GameOver(); // Call Game Over
            Destroy(collision.gameObject); // Destroy player
            Destroy(gameObject); // Destroy bullet
        }
    }
}
