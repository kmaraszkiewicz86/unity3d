using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ObstaclePrefabs;

    private PlayerController playerController;

    private BeginingPlayerAction beginingPlayerAction;

    private Vector3 startPosition = new Vector3(25, 0, 0);

    private Vector3 startPositionForDuplicateElement => new Vector3(startPosition.x, startPosition.y + 1.55f, startPosition.z);

    private float delayTime = 2;

    private float repeatRate = 2;

    private bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerGameObject = GameObject.Find("Player");
        playerController = playerGameObject.GetComponent<PlayerController>();
        beginingPlayerAction = playerGameObject.GetComponent<BeginingPlayerAction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (beginingPlayerAction.isBeginingActionRun || isStarted)
            return;

        InvokeRepeating(nameof(SpawnNewObstacle), delayTime, repeatRate);
        isStarted = true;
    }

    void SpawnNewObstacle()
    {
        if (playerController.isGameOver && beginingPlayerAction.isBeginingActionRun)
            return;

        var index = Random.Range(0, ObstaclePrefabs.Length);
        GameObject obstacle = ObstaclePrefabs[index];

        Instantiate(obstacle, startPosition, obstacle.transform.rotation);

        if (obstacle.CompareTag("ObstacleExtended") && Random.Range(0, 1000) % 2 == 0)
        {
            Instantiate(obstacle, startPositionForDuplicateElement, obstacle.transform.rotation);
        }
    }
}
