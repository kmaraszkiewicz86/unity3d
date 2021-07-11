using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    public float xRange = 20f;

    public float zMaximumPosition = 15f;

    public float zMinimumPosition = 0f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPlayerPositionIsInXRange();
        CheckIfPlayerPositionIsInZRange();

        HorizontalMovement();
        VerticalMovement();

        CreateProjectile();
    }

    private void CreateProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    private void HorizontalMovement()
    {
        var horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }

    private void VerticalMovement()
    {
        var verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }

    private void CheckIfPlayerPositionIsInXRange()
    {
        if (transform.position.x < -xRange)
            SetXPositionOfPlayer(-xRange);
        else if (transform.position.x > xRange)
            SetXPositionOfPlayer(xRange);
    }

    private void CheckIfPlayerPositionIsInZRange()
    {
        if (transform.position.z < zMinimumPosition)
            SetZPositionOfPlayer(zMinimumPosition);
        else if (transform.position.z > zMaximumPosition)
            SetZPositionOfPlayer(zMaximumPosition);
    }

    private void SetXPositionOfPlayer(float value)
    {
        transform.position = new Vector3(value, transform.position.y, transform.position.z);
    }

    private void SetZPositionOfPlayer(float value)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, value);
    }
}
