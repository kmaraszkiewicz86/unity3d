using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public int maxHealth = 5;
    public float speed = 3.0f;

    private const float _invincibleTimeout = 2.0f;
    private bool _isInvicible = false;
    private float _invincibleTimer;

    public int health => currentHealth;
    int currentHealth;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        _invincibleTimer = _invincibleTimeout;
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        StartCounting();
    }

    private void StartCounting()
    {
        if (!_isInvicible)
        {
            return;
        }

        _invincibleTimer -= Time.deltaTime;

        if (_invincibleTimer > 0)
            return;

        _invincibleTimer = _invincibleTimeout;
        _isInvicible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (_isInvicible)
                return;

            _isInvicible = true;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log($"{currentHealth}/{maxHealth}");
    }
}
