using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 100f;

    public float speed = 10f;

    public float gravityForce = 1f;

    public float zBoundLimit = 9.2f;

    public float xBoundLimit = 22.6f;

    private bool isAtBoundLimit = false;

    private bool isOnGround = true;

    private float horizontalMovement;

    private float verticalMovement;

    private Rigidbody playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityForce;
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        CheckBoundLimitConstarin();
    }

    private void PlayerMove()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        playerRigidBody.AddForce(Vector3.forward * verticalMovement * speed);
        playerRigidBody.AddForce(Vector3.right * horizontalMovement * speed);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isAtBoundLimit)
        {
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void CheckBoundLimitConstarin()
    {
        if (transform.position.z >= zBoundLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundLimit);
        }

        if (transform.position.z <= -zBoundLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBoundLimit);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter: " + other.gameObject.tag);

        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter: " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Powerup"))
        {
            Destroy(collision.gameObject);
        }
    }
}
