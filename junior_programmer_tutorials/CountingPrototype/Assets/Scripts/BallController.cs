using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.HelperData;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 10;

    private Rigidbody ballRigidBody;

    private SphereCollider ballsphereCollider;

    private GameManager gameManager;

    [SerializeField] private GameObject destination;

    public void ThrowAway(Transform playerTransform)
    {
        ballRigidBody.useGravity = true;
        ballsphereCollider.enabled = true;
        transform.parent = null;

        Vector3 powerVector = destination.transform.position - playerTransform.position;

        ballRigidBody.AddForce(powerVector * force, ForceMode.Impulse);
    }

    private void Awake()
    {
        ballRigidBody = GetComponent<Rigidbody>();
        ballsphereCollider = GetComponent<SphereCollider>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        destination = GameObject.Find("Destination");
    }

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        ballRigidBody.useGravity = false;
        ballsphereCollider.enabled = false;
        transform.position = destination.transform.position;
        transform.parent = destination.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            gameManager.CreateNewBall();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            gameManager.UpdateScore();
            gameManager.CreateNewBall();
        }
    }
}
