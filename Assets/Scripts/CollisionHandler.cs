using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    RocketMovement rocketMovement;

    public float levelLoadDelay = 1f;
    void Start()
    {
        rocketMovement = GetComponent<RocketMovement>();
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
            default:
                StartCrashSequence();
                break;
        }
    } 

    void StartCrashSequence(){
        rocketMovement.enabled = false;
        Invoke("ReloadLevel",levelLoadDelay);
    }

    void StartSuccessSequence(){
        rocketMovement.enabled = false;
        Invoke("LoadNextLevel",levelLoadDelay);
    }



    void ReloadLevel(){
        rocketMovement.enabled = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNexLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if(currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1 ){
           nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
        Invoke("ReloadLevel", levelLoadDelay);

    }
}