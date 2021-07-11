using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertical : MonoBehaviour
{
    public float speed;

    public FromPositionType fromPositionType; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (fromPositionType)
        {
            case FromPositionType.FromLeft:
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                break;

            case FromPositionType.FromRight:
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;
        }
    }
}
