using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollisionHandler : MonoBehaviour
{  
   public  int lives = 10;
   public int collisionTime = 250;
   public int dyingTime = 3000;
   public bool isColliding = false;
   public bool hasExploded = false;
   public AudioClip collisionSound;
   public AudioClip explosionSound;
   GameObject deathScreen;
   GameObject mainCamera;
   TextMeshProUGUI  livesText;
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
        livesText = GameObject.FindWithTag("livesText").GetComponent<TextMeshProUGUI>();
        mainCameraAudioSource = mainCamera.GetComponent<AudioSource>();
        deathScreen.SetActive(false);
        livesText.text = "Lives: " + lives;

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
            checkDeath();
            break;
        }
    }

    async void OnCollisionExit(Collision other) {
        if(lives >= 1) {
        meshRenderer.material.color = originalColor;
        await Task.Delay(collisionTime);
        isColliding = false;
        }
    }

    void HandleCollision(){
        if(lives >= 1){
        isColliding = true;
        meshRenderer.material.color = Color.red;
        audioSource.PlayOneShot(collisionSound, 0.7f);
        lives--;
        livesText.text = "Lives: " + lives;
    }
    }

    async void HandleDeath() {
        mainCameraAudioSource.Stop();
        hasExploded = true;
        meshRenderer.material.color = Color.black;
        audioSource.PlayOneShot(explosionSound, 0.7f);
        await Task.Delay(dyingTime);
        deathScreen.SetActive(true);
    }

    void checkDeath() {
        if(lives <= 0) {
            HandleDeath();
        }
    }
}
