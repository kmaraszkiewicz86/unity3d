using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;

    public float movementSpeed;

    private float verticalMovement;

    private float horizontalMovement;

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var z  = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;

        characterController.Move(movement * movementSpeed * Time.deltaTime);

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
