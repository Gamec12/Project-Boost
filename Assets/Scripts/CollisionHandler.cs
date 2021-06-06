using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip successAudio;
    [SerializeField] AudioClip failAudio;
    
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem failParticles;
    
    AudioSource audioSource;
    
    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    
    void Update()
    {
        DebugKeys();

    }

    void DebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled; // toggle collision
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning || collisionDisabled) { return; }

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
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successAudio);
        successParticles.Play();
        Invoke("LoadNextLevel", levelLoadDelay);
    }
    
    void startCrashSequence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(failAudio);
        failParticles.Play();
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