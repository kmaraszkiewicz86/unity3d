using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    private float boundLimit = 9.0f;

    private float delayTime = 2f;

    private float repeatTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InstiateNewEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstiateNewEnemy()
    {
        Instantiate(enemyPrefab, GenerateEnemyPosition(), enemyPrefab.transform.rotation);
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
