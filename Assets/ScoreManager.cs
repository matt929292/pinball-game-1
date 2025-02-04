using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class ScoreManager : MonoBehaviour
{
    private int currentScore = 0; // Initialize currentScore

    // Method to add score
    public void AddScore(int score)
    {
        currentScore += score;
    }

    // Method to get the current score
    public int GetCurrentScore()
    {
        return currentScore;
    }
}