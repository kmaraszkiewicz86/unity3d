using Assets.Scripts.Extenstions;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public GameObject enemy;

    public float speed = 5;

    private Rigidbody projectileRigidbody;

    private float boundLimit = 13;

    // Start is called before the first frame update
    void Start()
    {
        projectileRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > boundLimit 
            || transform.position.x < -boundLimit
            || transform.position.z > boundLimit
            || transform.position.x < -boundLimit)
        {
            Destroy(gameObject);
        }

        var distance = (enemy.transform.position - transform.position);

        projectileRigidbody.AddForce(distance * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.IsGameObjectEnemy())
        {
            var enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            var distanceFromEnemy = (collision.gameObject.transform.position - transform.position).normalized;

            enemyRigidBody.AddForce(distanceFromEnemy * 10, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
