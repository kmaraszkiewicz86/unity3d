using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ObstaclePrefab;

    private PlayerController playerController;

    private Vector3 startPosition = new Vector3(25, 0, 0);

    private float startDelay = 2;

    private float repeatRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnNewObstacle), startDelay, repeatRate);

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnNewObstacle()
    {
        if (playerController.isGameOver)
            return;

        Instantiate(ObstaclePrefab, startPosition, ObstaclePrefab.transform.rotation);
    }
}
