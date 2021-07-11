using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float topBound = 30f;

    public float lowerBound = -10f;

    public float leftBound = -25f;

    public float rightBound = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.transform.position.z < lowerBound
            || transform.transform.position.x < leftBound
            || transform.transform.position.x > rightBound)
        {
            PlayerModel.DecreaseLives();
            Destroy(gameObject);
        }
    }
}
