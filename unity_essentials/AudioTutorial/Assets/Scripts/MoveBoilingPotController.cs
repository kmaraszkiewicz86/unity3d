using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoilingPotController : MonoBehaviour
{
    public GameObject GameObject;

    private float _upSpeed = 0.01f;

    private float _upLimit = 2;

    private float _zAxisSpeed = -0.22f;

    private float _zAxisDistanceLimit = -1;

    private float _triggerDistance => transform.position.x + 2;

    private float _rotateSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject == null || GameObject.transform.position.x <= _triggerDistance)
        {
            Debug.Log("2");

            if (transform.position.y <= _upLimit)
            {
                transform.position += new Vector3(0, _upSpeed, 0);
            }
            else if (transform.position.y >= _upLimit && transform.position.z > _zAxisDistanceLimit)
            {
                transform.position += new Vector3(0.08f, 0, _zAxisSpeed);
            }
            else
            {
                if (transform.position.z >= -6)
                {
                    transform.position += new Vector3(0, 0, _zAxisSpeed);
                }
                else
                {
                    transform.Rotate(0, _rotateSpeed, 0);
                }
            }
        }
        else
        {
            Debug.Log($"{GameObject.transform.position.x} == {_triggerDistance}");
        }
    }
}
