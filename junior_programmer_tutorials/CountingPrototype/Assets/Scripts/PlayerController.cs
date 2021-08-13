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

    [SerializeField] private Vector3 mOffset;

    [SerializeField] private float mZCoord;

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

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
