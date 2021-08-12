using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnXPosition = 20f;

    private float spawnZPosition = 20f;

    private float startDelay = 2f;

    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), startDelay, spawnInterval);
    }

    private void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        GameObject choseAnimalPrefab = animalPrefabs[animalIndex];

        if (Random.Range(1, 100) % 2 == 1)
        {
            var startXPosition = spawnXPosition;
            var startRotationXPosition = -90;

            if (Random.Range(1, 100) % 2 == 1)
            {
                startXPosition = -startXPosition;
                startRotationXPosition = -startRotationXPosition;
            }

            Vector3 animalPositon = new Vector3(startXPosition, 0, Random.Range(3, 15));
            Instantiate(choseAnimalPrefab, animalPositon, Quaternion.Euler(0, startRotationXPosition, 0));
        }
        else
        {
            Vector3 animalPositon = new Vector3(Random.Range(-spawnXPosition, spawnXPosition), 0, spawnZPosition);
            Instantiate(choseAnimalPrefab, animalPositon, choseAnimalPrefab.transform.rotation);
        }
        
    }
}
