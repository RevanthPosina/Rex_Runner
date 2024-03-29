using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject Rex;
    public float cameraStickiness = 10f;
    public float cameraRotateSpeed = 5;
    public Transform cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = Vector3.Lerp(this.transform.position, cameraOffset.position, cameraStickiness * Time.deltaTime); //Lerp Action
        this.transform.position = cameraPos;    
        Quaternion lookDirection = Quaternion.LookRotation(Rex.transform.forward);
        lookDirection = Quaternion.Slerp(this.transform.rotation, lookDirection , cameraRotateSpeed * Time.deltaTime);
        this.transform.position = cameraPos;
        this.transform.rotation = lookDirection;
        
    }
}
