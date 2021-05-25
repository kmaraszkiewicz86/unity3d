using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaterController : MonoBehaviour
{
    private float Speed = 20.0f;

    private float TurnSpeed = 45.0f;

    private float horizontalInput;

    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        MoveForward();
        TurnOnAxis();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed * forwardInput);
    }

    private void TurnOnAxis()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * TurnSpeed * horizontalInput);
    }
}
