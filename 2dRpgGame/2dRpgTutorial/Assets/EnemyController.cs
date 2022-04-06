using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        if (vertical)
        {
            animator.SetFloat("MoveY", direction);
            animator.SetFloat("MoveX", 0);
        }
        else
        {
            animator.SetFloat("MoveY", 0);
            animator.SetFloat("MoveX", direction);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }

        rigidbody2D.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RubyController player = collision.gameObject.GetComponent<RubyController>();

        if (player == null)
            return;

        player.ChangeHealth(-1);
    }
}
