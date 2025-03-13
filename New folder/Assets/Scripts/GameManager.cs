using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // UI Score Text
    public GameObject gameOverPanel; // UI Game Over Panel
    private int score = 0; // Player's score

    void Start()
    {
        scoreText.text = "Score: " + score;
        gameOverPanel.SetActive(false); // Hide Game Over panel at start
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene("Credits"); // Load Credits Scene
    }
}
