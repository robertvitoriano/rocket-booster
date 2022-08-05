using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
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
                print("destroying");
                break;
        }
    }
}
