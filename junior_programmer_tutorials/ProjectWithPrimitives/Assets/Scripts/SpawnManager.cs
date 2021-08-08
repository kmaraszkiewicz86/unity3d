using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    private float boundLimit = 20f;

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

        Instantiate(enemy, enemyPosition, enemy.transform.rotation);
    }
}
