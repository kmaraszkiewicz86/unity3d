using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;

    public Rigidbody enemyRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRigidBody.AddForce(Vector3.forward * -speed);

        if (transform.position.z < -15)
        {
            Destroy(gameObject);
        }
    }
}
