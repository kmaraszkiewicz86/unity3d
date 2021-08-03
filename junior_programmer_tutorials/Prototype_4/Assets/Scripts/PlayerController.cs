using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    private bool hasPowerUp = false;

    private float powerUpStrength = 15f;

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
        var verticalInput = Input.GetAxis("Vertical");

        playerRigidBody.AddForce(focalPointGameObject.transform.forward * verticalInput * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnCollisionEnter");
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerUp = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            var enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            var awayPosition = collision.gameObject.transform.position - transform.position;

            enemyRigidBody.AddForce(awayPosition * powerUpStrength, ForceMode.Impulse);
        }
    }
}
