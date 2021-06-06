using UnityEngine;

public class PlaterController : MonoBehaviour
{
    public int PlayerNumber = 0;

    private float speed = 20.0f;

    private float turnSpeed = 45.0f;

    private string PlayerName
    {
        get
        {
            return PlayerNumber switch
            {
                1 => string.Empty,
                2 => "2",
                _ => string.Empty
            };
        }
    }

    private float HorizontalInput => Input.GetAxis($"Horizontal{PlayerName}");

    private float ForwardInput => Input.GetAxis($"Vertical{PlayerName}");

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        TurnOnAxis();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed * ForwardInput);
    }

    private void TurnOnAxis()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * HorizontalInput);
    }
}
