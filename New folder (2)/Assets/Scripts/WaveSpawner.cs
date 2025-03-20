using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
   public TextMeshProUGUI timerDisplay;
public TextMeshProUGUI waveDisplay;

    public int waveIndex = 0;

    [System.Serializable]
    public class Wave
    {
        public GameObject enemy;
        public int count;
        public float rate;
    }
 
   void Update()
{
    Debug.Log("Updating: EnemiesAlive = " + EnemiesAlive);

    if (EnemiesAlive > 0) {
        Debug.Log("Waiting for enemies to be cleared...");
        return;
    }

    if (waveIndex >= waves.Length)
    {
        Debug.Log("All waves completed. Stopping spawner.");
        this.enabled = false;
        return;
    }

   if (countdown <= 0f && EnemiesAlive <= 0)
{
    if (waveIndex < waves.Length)
    {
        StartCoroutine(SpawnWave());
        countdown = timeBetweenWaves; // Reset countdown after each wave
    }
    else
    {
        Debug.Log("No more waves to spawn.");
        this.enabled = false;
    }
}
else
{
    countdown -= Time.deltaTime;
    timerDisplay.text = Mathf.Floor(countdown).ToString();
}
 waveDisplay.text = "Wave: " + (waveIndex + 1).ToString() + " / " + waves.Length.ToString();




    IEnumerator SpawnWave()
{
    Debug.Log("SpawnWave started for wave index: " + waveIndex);
    Wave wave = waves[waveIndex];

    for (int i = 0; i < wave.count; i++)
    {
        SpawnEnemy(wave.enemy);
        Debug.Log("Spawning enemy " + (i+1) + " of " + wave.count);
        yield return new WaitForSeconds(1f / wave.rate);
    }

    waveIndex++;
    Debug.Log("SpawnWave completed for wave index: " + (waveIndex - 1));
}


    void SpawnEnemy(GameObject enemy)
    {
        Vector3 spawnPos = spawnPoint.position + new Vector3(0, 1f, 0);
        GameObject newEnemy = Instantiate(enemy, spawnPos, spawnPoint.rotation);
    }
}
}
