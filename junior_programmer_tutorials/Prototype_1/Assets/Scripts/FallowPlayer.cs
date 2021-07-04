using UnityEngine;

public class FallowPlayer : MonoBehaviour
{
    public GameObject GameObject;

    public int PlayerNumber = 0;

    private KeyCode ChangeCameraKeyCode
    {
        get
        {
            return PlayerNumber switch
            {
                1 => KeyCode.Space,
                2 => KeyCode.KeypadEnter,
                _ => KeyCode.Space
            };
        }
    }

    private bool cameraToggle;

    private Vector3[] offset = new Vector3[2]
    {
        new Vector3(0, 5, -7),
        new Vector3(0, 5, -2)
    };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(ChangeCameraKeyCode))
        {
            cameraToggle = !cameraToggle;
        }

        transform.position = GameObject.transform.position + offset[cameraToggle ? 1 : 0];
    }
}
