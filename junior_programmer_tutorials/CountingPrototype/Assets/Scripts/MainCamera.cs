using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void LateUpdate()
    {
        var cameraPosition = new Vector3(player.transform.position.x, player.transform.position.y + 0.45f, player.transform.position.z);
        var cameraRotation = player.transform.rotation;

        gameObject.transform.position = cameraPosition;
        gameObject.transform.rotation = player.transform.rotation;
    }
}
