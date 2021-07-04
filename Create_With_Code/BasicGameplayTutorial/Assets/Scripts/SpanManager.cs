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

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int positionIndex = Random.Range(0, 3);

        GameObject choseAnimalPrefab = animalPrefabs[animalIndex];
        Vector3 animalPositon = new Vector3(Random.Range(-spawnXPosition, spawnXPosition), 0, spawnZPosition);

        Instantiate(choseAnimalPrefab, animalPositon, choseAnimalPrefab.transform.rotation);
    }
}
