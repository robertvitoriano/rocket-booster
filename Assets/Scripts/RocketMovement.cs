using System.Collections;
using System.Collections.Generic;
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
    public ParticleSystem thrustParticles;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space)){
            rigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying){
                audioSource.PlayOneShot(mainEngine);
                thrustParticles.Play();
            }
        }else{
            audioSource.Stop();
            thrustParticles.Stop();
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
