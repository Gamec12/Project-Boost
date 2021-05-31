using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip successAudio;
    [SerializeField] AudioClip failAudio;
    
    AudioSource audioSource;
    
     void Start() 
    {
        audioSource = GetComponent<AudioSource>();   
    }
    
    
    void OnCollisionEnter(Collision other) 
    {
       switch(other.gameObject.tag)
       {
           case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                startFinishSequence();
                break;
            default:
                startCrashSequence();
                break;

        } 
    }
    
    void startFinishSequence()
    {
        // todo add particle effect upon finish 
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(successAudio);
        Invoke("LoadNextLevel", levelLoadDelay);
    }
    
    void startCrashSequence()
    {
        // todo add SFX upon crash
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(failAudio);
        Invoke("ReloadLevel", levelLoadDelay);         
    }     
        
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex ;
        int nextSceneIndex = currentSceneIndex + 1 ;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);        
    }
    
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex ;
        SceneManager.LoadScene(currentSceneIndex);
    }

}