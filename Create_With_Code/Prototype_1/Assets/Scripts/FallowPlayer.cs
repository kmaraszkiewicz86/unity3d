using UnityEngine;

public class FallowPlayer : MonoBehaviour
{
    public GameObject GameObject;

    private Vector3 _offset = new Vector3(0, 5, -7);

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
