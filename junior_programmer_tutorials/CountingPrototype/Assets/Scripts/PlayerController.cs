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



    // Update is called once per frame
    void Update()
    {
        verticalMovement = Input.GetAxis("Vertical");
        horizontalMovement = Input.GetAxis("Horizontal");

        gameObject.transform.Translate(Vector3.forward * verticalMovement * movementSpeed * Time.deltaTime);
        gameObject.transform.Rotate(Vector3.up * horizontalMovement * rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var destinationObject = GameObject.Find("Destination");

            if (destinationObject != null && destinationObject.transform.childCount > 0)
            {
                var ball = destinationObject.transform.GetChild(0);

                if (ball != null)
                {
                    var ballController = ball.GetComponent<BallController>();
                    ballController.ThrowAway(transform);
                }
            }
        }
    }
}
