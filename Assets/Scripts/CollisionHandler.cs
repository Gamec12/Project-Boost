using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
       switch(other.gameObject.tag)
       {
           case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                Debug.Log("Congrats! You finished the level");
                break;
            case "Fuel":
                Debug.Log("You got fuel"); //right now we will just bump into it as you can't pick it we are just playing around with siwtchup
                break;
            default:
                ReloadLevel();
                break;

        } 
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex ;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
