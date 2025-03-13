using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy prefab
    public Transform[] spawnPoints; // Array of spawn positions
    public float spawnRate = 5f; // Time between waves
    public int enemiesPerWave = 5; // Number of enemies per wave
    private int waveCount = 1; // Keep track of waves

    void Start()
    {
        InvokeRepeating(nameof(SpawnWave), 2f, spawnRate); // Start spawning waves
    }

    void SpawnWave()
    {
        Debug.Log("Spawning Wave " + waveCount);
        for (int i = 0; i < enemiesPerWave; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
        }
        waveCount++; // Increase wave count
    }
}
