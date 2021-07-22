using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    public float speed = 0.5f;

    private bool shouldMoveRight = true;

    private Vector3 direction = Vector3.right;

    private Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0.1f);

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        Material material = Renderer.material;

        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }

    void Update()
    {
        if (shouldMoveRight && transform.position.x > 3.5f)
        {
            direction = Vector3.left;
            shouldMoveRight = false;
        }
        else if (!shouldMoveRight && transform.position.x < -10f)
        {
            direction = Vector3.right;
            shouldMoveRight = true;
        }

        transform.Translate(direction * Time.deltaTime * speed);

        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);

        transform.localScale += scaleChange;

        // Move upwards when the sphere hits the floor or downwards
        // when the sphere scale extends 1.0f.
        if (transform.localScale.y < 0.1f || transform.localScale.y > 5.0f)
        {
            scaleChange = -new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
}
