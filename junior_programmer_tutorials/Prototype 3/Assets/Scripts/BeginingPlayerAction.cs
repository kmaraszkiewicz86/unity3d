using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginingPlayerAction : MonoBehaviour
{
    public bool isBeginingActionRun = true;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -3)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        else
        {
            animator.SetFloat("Speed_f", 1f);
            isBeginingActionRun = false;
        }
    }
}
