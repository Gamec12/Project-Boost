using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    [SerializeField] AudioClip easterEgg;

    AudioSource audioSource ;
    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }   
    void OnCollisionEnter(Collision other)
    {
        PlayEasterEgg();
    }

    private void PlayEasterEgg()
    {
        audioSource.PlayOneShot(easterEgg);
    }
}
