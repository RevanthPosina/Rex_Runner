using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RexAction : MonoBehaviour
{
    Animator anim;
    MoveRex moveRexScript;

    void Start()
    {
        anim = GetComponent<Animator>();
        moveRexScript = GetComponent<MoveRex>();
    }

    void Update()
    {
        HandleAnimations();
    }

    void HandleAnimations()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump"); //handling Rex Jump
        }

        // Determine if the Rex is running based on forward input
        float forwardInput = Input.GetAxisRaw("Vertical");
        bool isRunning = Mathf.Abs(forwardInput) > 0.1f;
        anim.SetBool("IsRunning", isRunning);
        Debug.Log(isRunning);
    }
}