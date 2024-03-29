using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRex : MonoBehaviour
{
    public float fowardSpeed = 10.0f;
    public float rotateSpeed = 80.0f;
    public float speedBoostMultiplier = 2.0f; // Speed is doubled during boost
    public float boostDuration = 3.0f; // Duration of the speed boost in seconds
    private bool isBoosted = false;
    private float normalSpeed;
    private float boostEndTime;
    

    // Start is called before the first frame update
    void Start()
    {
        normalSpeed = fowardSpeed; 
    }

   void Update()
    {
        MoveRexForwardBackward();
        TurnRexLeftRight();
        if (isBoosted && Time.time > boostEndTime)
        {
            fowardSpeed = normalSpeed; // Reset speed to normal
            isBoosted = false;
        }
    }

    void MoveRexForwardBackward()
    {
        // Move Melvin forward and backward with user input
        float forwardInput = Input.GetAxis("Vertical");
        this.transform.Translate(Vector3.forward * Time.deltaTime * forwardInput * fowardSpeed);
    }

    void TurnRexLeftRight()
    {
        float turnInput = Input.GetAxis("Horizontal");
        this.transform.Rotate(Vector3.up, turnInput * rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
    if (other.gameObject.CompareTag("Coin"))
    {
        ScoreManager.instance.AddScore(1); // Add 1 point for each coin collected
        Destroy(other.gameObject); // Remove the coin from the scene
    }

    if (other.gameObject.CompareTag("SpeedBoost"))
    {
        ScoreManager.instance.AddScore(5); // Add 5 points for each SpeedBoost collected
        Destroy(other.gameObject); // Remove the coin from the scene
        isBoosted = true;
        fowardSpeed *= speedBoostMultiplier; // Increase speed
        boostEndTime = Time.time + boostDuration; 
    }
    }

}
