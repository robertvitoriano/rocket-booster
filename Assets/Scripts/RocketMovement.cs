using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    float xValue;
    float yValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xValue = Input.GetAxis("Horizontal");
        yValue = Input.GetAxis("Vertical");
        transform.Translate(xValue, yValue, 0);
        
    }
}
