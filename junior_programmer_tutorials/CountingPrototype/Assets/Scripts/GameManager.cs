using Assets.Scripts.HelperData;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text countText;

    public GameObject ball;

    private int score = 0;

    private void Start()
    {
        CreateNewBall();
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        countText.text = $"Score: {++score}";
    }

    public void CreateNewBall()
    {
        Instantiate(ball, BallModel.initialPosition, ball.transform.rotation);
    }

    private float ColoNumberConversion()
    {
        return (Random.Range(0, 255) / 255.0f);
    }
}
