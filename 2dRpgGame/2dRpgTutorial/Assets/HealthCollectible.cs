using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var controller = collision.GetComponent<RubyController>();

        if (controller == null || controller.health >= controller.maxHealth)
        {
            return;
        }

        controller.ChangeHealth(1);
        Destroy(gameObject);
    }
}
