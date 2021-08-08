using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public GameObject enemyToFallow;

    public float speed = 20f;

    private Rigidbody projectileRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        projectileRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var distanceToEnemy = (enemyToFallow.transform.position - transform.position).normalized;

        projectileRigidbody.AddForce(distanceToEnemy  * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") )
    }
}
