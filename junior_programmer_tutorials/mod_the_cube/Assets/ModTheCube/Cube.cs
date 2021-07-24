using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    public float speed = 0.5f;

    private float opacity = 1f;

    private float opacityChange = 0.1f;

    private float powerUp = 1f;

    private float speedChange = 0.3f;

    private float rotationSpeed = 10.0f;

    private Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0.1f);

    private Color[] colors = new Color[] { Color.white, Color.black, Color.red, Color.green };

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        SetMaterialColor(new Color(0.5f, 1.0f, 0.3f, 0.4f));

        InvokeRepeating("ChangeColor", 1, 1);

        InvokeRepeating("ChangeSpeed", 1, 1);
    }

    void Update()
    {
        if (transform.position.x >= 5f || transform.position.x < -30f)
        {
            speed = -speed;
        }

        if (transform.localScale.y < 0.1f || transform.localScale.y > 5.0f)
        {
            scaleChange = -scaleChange;
        }

        if (transform.rotation.x >= 60 || transform.rotation.x <= -1)
        {
            rotationSpeed = -rotationSpeed;
        }

        transform.Translate(Vector3.right * Time.deltaTime * (speed * powerUp));

        var rotation = powerUp * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation, 0.0f, 0.0f);

        transform.localScale += scaleChange;
    }

    private void ChangeSpeed()
    {
        if (powerUp < 1 || powerUp > 3)
        {
            speedChange = -speedChange;
        }

        powerUp += speedChange;
    }

    private void ChangeColor()
    {
        int colorType = Random.Range(0, 3);
        float colorVolume = Random.Range(0f, 10f);
        
        if (opacity >= 1 || opacity <= 0.1f)
        {
            opacityChange = -opacityChange;
        }

        opacity += opacityChange;

        switch (colorType)
        {
            case 1:
                SetMaterialColor(new Color(colorVolume, 0.0f, 0.0f, opacity));
                break;

            case 2:
                SetMaterialColor(new Color(0.0f, colorVolume, 0.0f, opacity));
                break;

            case 3:
                SetMaterialColor(new Color(0.0f, 0.0f, colorVolume, opacity));
                break;
        }

        SetMaterialColor(colors[Random.Range(0, colors.Length)]);
    }

    private void SetMaterialColor(Color color)
    {
        Material material = Renderer.material;

        material.color = color;
    }
}
