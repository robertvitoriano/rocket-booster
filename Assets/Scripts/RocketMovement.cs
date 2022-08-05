using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    float xValue;
    float yValue;
    [SerializeField] float mainThrust = 100.0f;
    [SerializeField] float rotationThrust = 4.0f;
    Rigidbody rigidbody;
    AudioSource audioSource;
    [SerializeField] AudioClip mainEngine;
    CollisionHandler collisionHandler;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        collisionHandler = GetComponent<CollisionHandler>();
    }

    void Update()
    {
        if(collisionHandler.lives <= 0)
        {
            return;
        }
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space)){
            rigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying){
                audioSource.PlayOneShot(mainEngine, 0.7f);
            }
        }else {
            if(collisionHandler.isColliding){
                return;
            }
            audioSource.Stop();
        }
    }

    void ProcessRotation(){
        if(Input.GetKey(KeyCode.A)){
            ApplyRotation(rotationThrust);
        }
       else if(Input.GetKey(KeyCode.D)){
            ApplyRotation(-rotationThrust);
        };
    }

    void ApplyRotation(float rotationThisFrame ){
        rigidbody.freezeRotation = true; // take manual control of rotation
        transform.Rotate( Vector3.forward * rotationThisFrame * Time.deltaTime);
        rigidbody.freezeRotation = false;
    }
}
