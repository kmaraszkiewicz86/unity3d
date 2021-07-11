using UnityEngine;

public static class PlayerModel
{
    private static int playerLives = 3;

    private static int playerScore = 0;

    public static void IncreaseScore()
    {
        playerScore++;
        Debug.Log($"Scores: {playerScore}");
    }

    public static void DecreaseLives()
    {
        playerLives--;

        Debug.Log($"Lives: {playerLives}");

        if (playerLives <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
