using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("out?");

        if (collision.gameObject.CompareTag("Background"))
        {
            Debug.Log("out!");
        }
    }
}
