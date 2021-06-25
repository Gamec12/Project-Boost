using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocillator : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector; 
    [SerializeField] float movementFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        startingPosition = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon){ return;}
        float cycles = Time.time / period; // continually growing over time 
        
        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1
        
        movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1 so it's cleaner
        
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset; //startingPosition was important the transform.position changes
        //transform.Translate(offset); this doesn't work since it will continue to move it every frame but the one above will only change it's possition not add to it     
    }
}
