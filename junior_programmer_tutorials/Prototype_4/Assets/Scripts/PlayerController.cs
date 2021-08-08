using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Extenstions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    public GameObject powerupIndicator;

    public bool IsGameOver = false;

    public GameObject projectilePrefab;

    private bool hasPowerUp = false;

    private float powerUpStrength = 10f;

    private Rigidbody playerRigidBody;

    private GameObject focalPointGameObject;

    // Start is called before the first frame update
    void Start()
    {
        //enemyPrefabs = new List<GameObject>();

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
    }

    private void FireToAllEnemies()
    {
        FireToAllEnemies(GameObject.FindGameObjectsWithTag("Enemy"));
        FireToAllEnemies(GameObject.FindGameObjectsWithTag("EnemyWithPowerup"));
    }

    private void FireToAllEnemies(GameObject[] gameObjects)
    {
        if ((gameObjects != null && gameObjects.Length > 0) && hasPowerUp)
        {
            for (var enemyPrefabIndex = 0; enemyPrefabIndex < gameObjects.Length; enemyPrefabIndex++)
            {
                var enemy = gameObjects[enemyPrefabIndex];
                var projectileRigidBody = projectilePrefab.GetComponent<Rigidbody>();
                var projectileMove = projectilePrefab.GetComponent<ProjectileMove>();

                projectileMove.enemy = enemy;

                Instantiate(projectilePrefab, new Vector3(transform.position.x, 0, transform.position.z), projectilePrefab.transform.rotation);

                projectileRigidBody.AddForce((enemy.transform.position - projectilePrefab.transform.position).normalized * 10f, ForceMode.Impulse);
            }
        }
        else
        {
            CancelInvoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            InvokeRepeating(nameof(FireToAllEnemies), 0.5f, 2);

            hasPowerUp = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator DelayBeforNextFire()
    {
        yield return new WaitForSeconds(0.2f);
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.IsGamebjectEnemyWithPowerup() && !hasPowerUp)
        {
            var awayPosition = (transform.position - collision.gameObject.transform.position).normalized;

            playerRigidBody.AddForce(awayPosition * powerUpStrength, ForceMode.Impulse);
        }
        else if ((collision.gameObject.IsGameObjectEnemy()) 
            && hasPowerUp)
        {
            var enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            var awayPosition = (collision.gameObject.transform.position - transform.position).normalized;

            enemyRigidBody.AddForce(awayPosition * powerUpStrength, ForceMode.Impulse);
        }
    }
}