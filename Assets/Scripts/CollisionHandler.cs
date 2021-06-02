using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip successAudio;
    [SerializeField] AudioClip failAudio;
    
    AudioSource audioSource;
    
    bool isTransitioning = false;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();   
    }
    
    
    void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning) { return; }

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
        isTransitioning = true;
        // todo add particle effect upon finish 
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successAudio);
        Invoke("LoadNextLevel", levelLoadDelay);
    }
    
    void startCrashSequence()
    {
        isTransitioning = true;
        // todo add particle effect upon crash
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
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