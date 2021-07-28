using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 15f;

    public float gravityModifier = 2;

    public bool isOnGround = true;

    public bool isGameOver = false;

    public float speedPower = 1f;

    public ParticleSystem explosionParticle;

    public ParticleSystem dustParticle;

    public AudioClip jumpAudio;

    public AudioClip crashAudio;

    private AudioSource audioSource;

    private Rigidbody playerRigidBody;

    private Animator playerAnimator;

    private BeginingPlayerAction beginingPlayerAction;

    private int jumpTimes = 0;

    private bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        beginingPlayerAction = GetComponent<BeginingPlayerAction>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (beginingPlayerAction.isBeginingActionRun)
            return;

        if (!isStarted)
        {
            dustParticle.Play();
            isStarted = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpTimes < 2 && !isGameOver)
        {
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");
            dustParticle.Stop();
            audioSource.PlayOneShot(jumpAudio, 5.0f);
            jumpTimes++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpTimes = 0;

            if (!isGameOver)
                dustParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") ||
            collision.gameObject.CompareTag("ObstacleExtended"))
        {
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 2);

            Debug.Log("Game over");
            isGameOver = true;

            explosionParticle.Play();
            dustParticle.Stop();

            audioSource.PlayOneShot(crashAudio, 8.0f);
        }
    }
}
