using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTransform : MonoBehaviour
{
    public Vector3 scaleChange;

    public Vector3 rotateChange;

    public Vector3 positionChange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += scaleChange;
        transform.Rotate(rotateChange);
        transform.position += positionChange;
    }
}
