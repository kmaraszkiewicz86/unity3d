using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    public GameObject powerupPrefab;

    private GameObject player;

    private PlayerController playerController;

    private float boundLimit = 9.0f;

    private float delayTime = 2f;

    private float repeatTime = 2f;

    private int amountOfEnemies = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        InstiateNewEnemies(amountOfEnemies++);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.IsGameOver)
        {
            Destroy(gameObject);
        }

        int enemyLength = FindObjectsOfType<Enemy>().Length;

        if (enemyLength == 0 && !playerController.IsGameOver) InstiateNewEnemies(amountOfEnemies++);
    }

    private void InstiateNewEnemies(int amountOfEnemies)
    {
        for (var index = 0; index < amountOfEnemies; index++)
        {
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            Instantiate(enemyPrefab, GenerateEnemyPosition(), enemyPrefab.transform.rotation);
            Instantiate(powerupPrefab, GenerateEnemyPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateEnemyPosition()
    {
        return new Vector3(GetRandomPosition(), 0, GetRandomPosition());
    }

    private float GetRandomPosition()
    {
        return Random.Range(-boundLimit, boundLimit);
    }
}
