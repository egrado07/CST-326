using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    public float speed = 10f;
    public float startSpeed = 10f;  // Initialize startSpeed to match speed or any other value as necessary
    private Transform target;
    private int wavepointIndex = 0;
    public int moneyValue = 10;  // Money reward per enemy

    void Start()
    {
        speed = startSpeed;  // Ensure speed starts with the intended startSpeed
        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        wavepointIndex = 0;
        target = Waypoints.points[wavepointIndex]; 
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndGame();
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    public void TakeDamage(float amount)
{
    Debug.Log("Damage taken: " + amount); // Confirm damage application
    health -= amount;
    if (health <= 0f)
    {
        Die();
    }
}


    void Die()
    {
        PlayerStats.Money += moneyValue; // Add money when an enemy dies
        Debug.Log(" Earned 10 money! Total: " + PlayerStats.Money);
        Destroy(gameObject);
    }

    public void Slow(float slowFactor)
    {
        speed *= (1f - slowFactor);  // Slow the enemy by reducing speed
    }

    void EndGame()
    {
        Debug.Log(" GAME OVER! Enemies reached your base!");
        Time.timeScale = 0; // Stops the game
    }
}
