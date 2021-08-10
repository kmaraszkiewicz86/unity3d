using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameOvetText;

    private int score;

    private float spawnRate = 1.0f;

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;

        scoreText.text = $"Score: {score}";
    }

    public void GameOver()
    {
        gameOvetText.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnTargets());
        score = 0;
        UpdateScore(0);
    }

    private IEnumerator SpawnTargets()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            var index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }


}
