using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;

    public float leftBound = -15f;

    private float speedPower = 1f;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedPower = 2f;
        }
        else
        {
            speedPower = 1f;
        }

        if (!playerController.isGameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * (speed * speedPower));
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
