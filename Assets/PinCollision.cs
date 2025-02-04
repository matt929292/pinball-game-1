using UnityEngine;
using TMPro;

public class PinCollision : MonoBehaviour
{
    public int scoreValue = 10; // Points for touching the pin
    private ScoreManager scoreManager;
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found!");
        }

        if (scoreText == null)
        {
            Debug.LogError("ScoreText not assigned!");
        }

        UpdateScoreText(); // Initialize score text at the start
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            scoreManager.AddScore(scoreValue);
            UpdateScoreText(); // Update score text after adding score
        }
    }

    void UpdateScoreText()
    {
        // Check if scoreManager is not null
        if (scoreManager != null)
        {
            int currentScore = scoreManager.GetCurrentScore();
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }
}
