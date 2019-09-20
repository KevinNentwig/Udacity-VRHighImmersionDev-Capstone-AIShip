using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour {

    private float hoursOfDay = 5f;

	// Update is called once per frame
	void Update ()
    {
        // rotate the object around the center of the scene on it's right axis
        transform.RotateAround(Vector3.zero, Vector3.right, hoursOfDay * Time.deltaTime);

        // rotates the object so the forward vector points at the center of the scene
        transform.LookAt(Vector3.zero);
    }
}
