using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;

    public float speed = 10f;

    public float xRange = 10f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.z > 30)


        CheckIfPlayerPositionIsInXRange();
        
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    private void CheckIfPlayerPositionIsInXRange()
    {
        if (transform.position.x < -xRange)
            SetXPositionOfPlayer(-xRange);
        else if (transform.position.x > xRange)
            SetXPositionOfPlayer(xRange);
    }

    private void SetXPositionOfPlayer(float value)
    {
        transform.position = new Vector3(value, transform.position.y, transform.position.z);
    }
}
