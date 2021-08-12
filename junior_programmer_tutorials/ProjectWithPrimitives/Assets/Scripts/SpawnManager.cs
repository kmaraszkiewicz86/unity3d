using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    public GameObject powerUp;

    private float boundLimit = 20f;

    private float boundXLimitForPowerUp = 14f;

    private float bound4LimitForPowerUp = 14f;

    private float startDelay = 2;

    private float repeatInterval = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(CreateNewEnemy), startDelay, repeatInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateNewEnemy()
    {
        GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        Vector3 enemyPosition = new Vector3(Random.Range(-boundLimit, boundLimit), 0.7f, 10f);
        Vector3 powerUpPosition = new Vector3(Random.Range(-boundXLimitForPowerUp, boundXLimitForPowerUp), 0.7f, Random.Range(0, 5));

        Instantiate(enemy, enemyPosition, enemy.transform.rotation);
        Instantiate(powerUp, powerUpPosition, powerUp.transform.rotation);
    }
}
