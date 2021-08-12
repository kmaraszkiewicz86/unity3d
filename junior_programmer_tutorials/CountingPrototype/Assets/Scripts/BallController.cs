using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject box;
    
    [SerializeField] private Vector3 mOffset;

    [SerializeField] private float mZCoord;

    private Rigidbody ballRigidBody;



    private void Start()
    {
        ballRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
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
