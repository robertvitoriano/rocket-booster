using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class CollisionHandler : MonoBehaviour
{
    public float levelLoadDelay = 3f;

    [SerializeField] AudioClip success;
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip collision;

    RocketMovement rocketMovement;
    AudioSource audioSource;

    bool isTransitioning = false;

    void Start()
    {
        rocketMovement = GetComponent<RocketMovement>();
        audioSource = GetComponent<AudioSource>();

    }
    void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag) {
            case "Landing Pad":
                StartSuccessSequence();
                break;
            case "Launch Pad":
                print("Launch Pad");
                break;
            case "Fuel":
                print("Fuel");
                break;
            case "Friendly":
                print("Friendly");
                break;
            default:
                StartCrashSequence();
                break;
        }
    } 

    void StartCrashSequence(){
        if(!isTransitioning){
            isTransitioning = true;
            audioSource.PlayOneShot(collision);
            rocketMovement.enabled = false;
            Invoke("ReloadLevel", levelLoadDelay);
        }
    }

    void StartSuccessSequence(){
        if(!isTransitioning){
            isTransitioning = true;
            audioSource.PlayOneShot(success);
            rocketMovement.enabled = false;
            Invoke("LoadNextLevel", levelLoadDelay);
        }

    }



    void ReloadLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        rocketMovement.enabled = true;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if(currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1 ){
           nextSceneIndex = 0;
        }

        rocketMovement.enabled = true;
        SceneManager.LoadScene(nextSceneIndex);
    }
}