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

    public TextMeshProUGUI livesText;

    public Button restartButton;

    public bool isGameActive;

    public GameObject pauseScreen;

    public bool IsGamePaused => pauseScreen.activeInHierarchy;

    private int lives;

    public GameObject titleScreen;

    private int score;

    private float spawnRate = 1.0f;

    private void Start()
    {
        //pauseScreen = GameObject.Find("Pause Screen");
        titleScreen = GameObject.Find("Title Screen");
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;

        scoreText.text = $"Score: {score}";
    }

    public int UpdatePlayerLives()
    {
        if (lives <= 0)
            return 0;

        lives--;
        livesText.text = $"Lives: {lives}";

        return lives;
    }

    public void StartGame(int difficuty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTargets());
        score = 0;
        lives = 10;
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
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGameActive)
        {
            TogglePauseScreen();
        }
    }

    private void TogglePauseScreen()
    {
        pauseScreen.SetActive(!pauseScreen.gameObject.activeInHierarchy);
        SetGravityForAllObjects(!pauseScreen.gameObject.activeInHierarchy);
        if (!pauseScreen.gameObject.activeInHierarchy)
        {
            StartCoroutine(SpawnTargets());
        }
        else
        {
            StopAllCoroutines();
        }
    }

    public void SetGravityForAllObjects(bool value)
    {
        GameObject[] allGameObjects = FindObjectsOfType<GameObject>();
        Rigidbody objectRigidBody = null;

        foreach (GameObject gameObject in allGameObjects)
        {
            objectRigidBody = gameObject?.GetComponent<Rigidbody>();

            if (objectRigidBody != null)
            {
                objectRigidBody.constraints = value
                    ? RigidbodyConstraints.None
                    : RigidbodyConstraints.FreezeAll;

                if (value)
                {
                    gameObject?.GetComponent<Target>()?.StartTorqueObject();
                    objectRigidBody.freezeRotation = false;
                }
            }
        }
    }

    private IEnumerator SpawnTargets()
    {
        while (isGameActive && !pauseScreen.gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(spawnRate);
            var index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }


}
