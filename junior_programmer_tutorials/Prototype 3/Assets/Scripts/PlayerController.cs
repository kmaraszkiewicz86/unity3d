using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 15f;

    public float gravityModifier = 2;

    public bool isOnGround = true;

    public bool isGameOver = false;

    public ParticleSystem explosionParticle;

    public ParticleSystem dustParticle;

    public AudioClip jumpAudio;

    public AudioClip crashAudio;

    private AudioSource audioSource;

    private Rigidbody playerRigidBody;

    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;

        dustParticle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dustParticle.Stop();
            audioSource.PlayOneShot(jumpAudio, 5.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

            if (!isGameOver)
                dustParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
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
