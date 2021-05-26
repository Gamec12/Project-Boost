using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float upThrust = 100f;
    [SerializeField] float rotationThrust = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
       ProcessThrust(); //calling method ProcessInput
       ProcessRotation();
    }


    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up *Time.deltaTime*upThrust);
        }


    }
    void ProcessRotation()
    {
         if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);  
        }

    }

    void ApplyRotation(float rotationThisFrame)
    {
       
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
