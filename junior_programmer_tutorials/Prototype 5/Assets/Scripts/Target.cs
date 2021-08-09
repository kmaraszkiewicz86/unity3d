 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        targetRigidBody = GetComponent<Rigidbody>();

        targetRigidBody.AddForce(Vector3.up * Random.Range(15, 18), ForceMode.Impulse);
        targetRigidBody.AddTorque(new Vector3(GetRandomAxix(), GetRandomAxix(), GetRandomAxix()), ForceMode.Impulse);

        transform.position = new Vector3(Random.Range(-4, 4), -6);
    }

    private float GetRandomAxix()
    {
        return Random.Range(-10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
