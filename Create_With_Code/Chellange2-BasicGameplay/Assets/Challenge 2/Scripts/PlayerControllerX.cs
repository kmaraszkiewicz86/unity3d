using System;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private Vector3 Vector3 = new Vector3(-1, 0, 0);

    private DateTime lastKeyPressedDatetime = DateTime.MinValue;
    private int pressKeyIntervalLimitInSecond = 1;

    private bool CanUserPressKey => (DateTime.Now - lastKeyPressedDatetime) > TimeSpan.FromSeconds(pressKeyIntervalLimitInSecond);

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{(DateTime.Now - lastKeyPressedDatetime)} -> {CanUserPressKey}");

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && CanUserPressKey)
        {
            Instantiate(dogPrefab, transform.position - Vector3, dogPrefab.transform.rotation);
            lastKeyPressedDatetime = DateTime.Now;
        }
    }
}
