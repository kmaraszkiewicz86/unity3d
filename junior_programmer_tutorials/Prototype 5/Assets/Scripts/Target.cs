using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue = 0;

    public ParticleSystem explosionParticleSystem;

    private Rigidbody targetRigidBody;

    private GameManager gameManager;

    private float RandomTorque => Random.Range(-maxTorque, maxTorque);

    private readonly float maxTorque = 10f;

    private Vector3 RandomSpeed => Vector3.up * Random.Range(minSpeed, maxSpeed);

    private readonly float minSpeed = 12f;

    private readonly float maxSpeed = 16f;

    private Vector3 RandomPosition => new Vector3(Random.Range(-xRange, xRange), ySpawnPos);

    private readonly float xRange = 4f;

    private readonly float ySpawnPos = -2f;

    public void StartTorqueObject()
    {
        targetRigidBody.AddTorque(new Vector3(RandomTorque, RandomTorque, RandomTorque), ForceMode.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        targetRigidBody = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRigidBody.AddForce(RandomSpeed, ForceMode.Impulse);
        StartTorqueObject();

        transform.position = RandomPosition;
    }

    private void OnMouseDown()
    {
        if (!gameManager.isGameActive || gameManager.IsGamePaused)
            return;

        Destroy(gameObject);

        gameManager.UpdateScore(pointValue);

        Instantiate(explosionParticleSystem, transform.position, explosionParticleSystem.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.tag);

        if (!gameObject.CompareTag("Bad"))
        {
            if (gameManager.UpdatePlayerLives() <= 0)
            {
                gameManager.GameOver();
            }
        }

        Destroy(gameObject);

    }
}
