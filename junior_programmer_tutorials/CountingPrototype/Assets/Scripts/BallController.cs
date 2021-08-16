using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Vector3 mOffset;

    [SerializeField] private float mZCoord;

    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(player.transform.position).z;

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
