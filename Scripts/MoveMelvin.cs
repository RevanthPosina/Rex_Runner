using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMelvin : MonoBehaviour
{
    public float fowardSpeed = 10.0f;
   // public float nitroboost = 20;
    public float rotateSpeed = 80f;
    //float currentSpeed = 0;
   // public float acceleration = 10;
    //public float deceleration = 5;
   // public float maxSpeed = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   void Update()
    {
        MoveMelvinForwardBackward();
        TurnMelvinLeftRight();
    }

    void MoveMelvinForwardBackward()
    {
        // Move Melvin forward and backward with user input
        float forwardInput = Input.GetAxis("Vertical");
        this.transform.Translate(Vector3.forward * Time.deltaTime * forwardInput * fowardSpeed);
    }

    void TurnMelvinLeftRight()
    {
        float turnInput = Input.GetAxis("Horizontal");
        this.transform.Rotate(Vector3.up, turnInput * rotateSpeed * Time.deltaTime);

        //float rotateInput = Input.GetAxis("Horizontal");
        //rotateInput *= rotateSpeed;
       //rotateInput *= Time.deltaTime;
        //this.transform.Rotate(0, rotateInput, 0);
    }
}