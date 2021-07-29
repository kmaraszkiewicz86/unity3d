using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody playerRigidBody;

    private GameObject focalPointGameObject;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        focalPointGameObject = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        var verticalInput = Input.GetAxis("Vertical");

        playerRigidBody.AddForce(focalPointGameObject.transform.forward * verticalInput * speed);
    }
}
