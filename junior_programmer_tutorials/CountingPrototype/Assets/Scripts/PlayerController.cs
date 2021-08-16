using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;

    public float rotationSpeed;

    public GameObject box;

    private float verticalMovement;

    private float horizontalMovement;

    private Rigidbody ballRigidBody;

    // Update is called once per frame
    void Update()
    {
        verticalMovement = Input.GetAxis("Vertical");
        horizontalMovement = Input.GetAxis("Horizontal");

        gameObject.transform.Translate(Vector3.forward * verticalMovement * movementSpeed * Time.deltaTime);
        gameObject.transform.Rotate(Vector3.up * horizontalMovement * rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 distance = (box.transform.position - transform.position).normalized;

            ballRigidBody.AddForce(distance * 5, ForceMode.Impulse);
        }
    }
}
