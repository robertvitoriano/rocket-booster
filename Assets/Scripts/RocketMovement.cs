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

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Landing Pad") {
            Debug.Log("Landed");
        }
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space)){
            rigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            Debug.Log("Thrusting");
        };
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
