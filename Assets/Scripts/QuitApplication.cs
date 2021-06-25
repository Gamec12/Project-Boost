using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {  
            Debug.Log("You quit the application");    
            Application.Quit();
        }       
    }
}
