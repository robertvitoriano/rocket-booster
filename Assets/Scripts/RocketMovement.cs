using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    float xValue;
    float yValue;
    [SerializeField]int upForce = 10;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space)){
            rigidbody.AddRelativeForce(Vector3.up * upForce);
        };
    }

    void ProcessRotation(){
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.forward * upForce * 0.5f);
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.Rotate(Vector3.back * upForce*0.5f);
        };

    }
}
