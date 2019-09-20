using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : MonoBehaviour {

    private BoatControllerScript boatController;
    public bool isHeld;

    private void Start()
    {
        // find the boat movement script
        boatController = GameObject.Find("ColonialShip").GetComponent<BoatControllerScript>();
    }

    // when the user enters the collider of the steering wheel turn on held status
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Right Hand" || other.gameObject.name == "Left Hand")
        {
            isHeld = true;
        }
    }

    // when the user exits the collider of the steering wheel turn of held status
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Right Hand" || other.gameObject.name == "Left Hand")
        {
            isHeld = false;
        }
    }
}
