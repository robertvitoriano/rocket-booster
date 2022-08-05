using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollisionHandler : MonoBehaviour
{  
   public  int lives = 5;
   public int collisionTime = 250;
   public int dyingTime = 3000;
   public bool isColliding = false;
   public bool hasExploded = false;
   public AudioClip collisionSound;
   public AudioClip explosionSound;
   GameObject deathScreen;
   GameObject mainCamera;
   Color originalColor;
   MeshRenderer meshRenderer;
   AudioSource audioSource;
   AudioSource mainCameraAudioSource;
   
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
        originalColor = meshRenderer.material.color;
        deathScreen = GameObject.FindWithTag("deathScreen");
        mainCamera = GameObject.FindWithTag("MainCamera");
        mainCameraAudioSource = mainCamera.GetComponent<AudioSource>();
        deathScreen.SetActive(false);
    }
    void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag) {
            case "Landing Pad":
                print("Landed");
                break;
            case "Launch Pad":
                print("Launch");
                break;
            case "Fuel":
                print("Fuel");
                break;
            default:
            HandleCollision();
            break;
        }
    }

    async void OnCollisionExit(Collision other) {
        meshRenderer.material.color = originalColor;
        await Task.Delay(collisionTime);
        isColliding = false;

    }

    void HandleCollision(){
        isColliding = true;
        meshRenderer.material.color = Color.red;
        audioSource.PlayOneShot(collisionSound, 0.7f);
        lives--;
        if(lives <= 0) {
          if(!hasExploded){
            HandleDeath();
          }
        }
    }

    async void HandleDeath() {
        mainCameraAudioSource.Stop();
        hasExploded = true;
        meshRenderer.material.color = Color.black;
        audioSource.PlayOneShot(explosionSound, 0.7f);
        deathScreen.SetActive(true);
        await Task.Delay(dyingTime);
        // Show death screen

    }
}
