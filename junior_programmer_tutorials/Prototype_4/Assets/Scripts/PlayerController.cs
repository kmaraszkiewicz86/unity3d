using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    public GameObject powerupIndicator;

    public bool IsGameOver = false;

    public GameObject[] enemyPrefabs;

    private bool hasPowerUp = false;

    private float powerUpStrength = 10f;

    private Rigidbody playerRigidBody;

    private GameObject focalPointGameObject;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        focalPointGameObject = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameOver)
            return;

        if (transform.position.y < -10)
        {
            IsGameOver = true;
        }

        var verticalInput = Input.GetAxis("Vertical");

        playerRigidBody.AddForce(focalPointGameObject.transform.forward * verticalInput * speed);

        powerupIndicator.gameObject.transform.position = transform.position - new Vector3(0, 0.5f, 0);

        if (enemyPrefabs != null && enemyPrefabs.Length > 0)
        {
            for (var enemyPrefabIndex = 0; enemyPrefabIndex < enemyPrefabs.Length; enemyPrefabIndex++)
            {
                //Instantiate()
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyWithPowerup") && !hasPowerUp)
        {
            var awayPosition = transform.position - collision.gameObject.transform.position;

            playerRigidBody.AddForce(awayPosition * powerUpStrength, ForceMode.Impulse);
        }
        else if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyWithPowerup")) 
            && hasPowerUp)
        {
            var enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            var awayPosition = collision.gameObject.transform.position - transform.position;

            enemyRigidBody.AddForce(awayPosition * powerUpStrength, ForceMode.Impulse);
        }
    }
}
