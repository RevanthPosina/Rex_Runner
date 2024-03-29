using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelvinAction : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }   
        
        float verticalInput = Input.GetAxisRaw("Vertical");
        bool isRunning = Mathf.Abs(verticalInput) > 0.1f;
        anim.SetBool("Run", isRunning);
    }
}
