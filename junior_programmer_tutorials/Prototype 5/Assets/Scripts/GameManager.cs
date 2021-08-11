using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameOvetText;

    public Button restartButton;

    public bool isGameActive;

    private int score;

    private float spawnRate = 1.0f;

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;

        scoreText.text = $"Score: {score}";
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOvetText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    private void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnTargets());
        score = 0;
        UpdateScore(0);
    }

    private IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            var index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }


}
