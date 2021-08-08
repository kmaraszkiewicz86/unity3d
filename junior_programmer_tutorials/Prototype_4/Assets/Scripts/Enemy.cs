using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody enemyRigidBody;

    private GameObject player;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("NotDestroy");

        if (transform.position.y < -10)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }

        if (playerController.IsGameOver)
            return;

        Vector3 moveDirection = (player.transform.position - transform.position).normalized;

        enemyRigidBody.AddForce(moveDirection * speed);

    }
}