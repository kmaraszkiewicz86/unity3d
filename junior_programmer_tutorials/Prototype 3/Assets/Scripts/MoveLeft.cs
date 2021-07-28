using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;

    public float leftBound = -15f;

    private float speedPower = 1f;

    private PlayerController playerController;

    private BeginingPlayerAction beginingPlayerAction;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        beginingPlayerAction = player.GetComponent<BeginingPlayerAction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (beginingPlayerAction.isBeginingActionRun)
            return;

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
