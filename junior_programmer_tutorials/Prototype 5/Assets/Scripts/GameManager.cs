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

    public GameObject titleScreen;

    private int score;

    private float spawnRate = 1.0f;

    private void Start()
    {
        titleScreen = GameObject.Find("Title Screen");
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;

        scoreText.text = $"Score: {score}";
    }

    public void StartGame(int difficuty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTargets());
        score = 0;
        UpdateScore(0);
        titleScreen.SetActive(false);

        spawnRate /= difficuty;
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
