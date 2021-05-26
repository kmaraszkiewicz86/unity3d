using UnityEngine;

public class FallowPlayer : MonoBehaviour
{
    public GameObject GameObject;

    public float x = 0f;

    public float y = 5f;

    public float z = -7f;

    private Vector3 _offset => new Vector3(x, y, z);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = GameObject.transform.position + _offset;
    }
}
