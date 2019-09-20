using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatControllerScript : MonoBehaviour {

    public GameObject steeringWheel;
    public Vector3 COM; // center of mass
    private Transform m_COM;

    public float speed = 1f;
    public float steerSpeed;
    public float movementThreshold = 10f;
    public float verticalInput;
    public float verticalRate = 0.1f;
    public float horizontalInput;
    public float horizontalOutput;
    public float horizontalRate = 0.1f;
    private float maxVerticalInput = 0.5f;
    private float maxHorizontalOutput = 1f;
    float movementFactor;
    float steerFactor;

    public float steerAngle;

    private void Awake()
    {
        // get the steering wheel of the ship
        steeringWheel = GameObject.Find("Wheel");
    }

    // Update is called once per frame
    void Update ()
    {
        Balance();
        Movement();
        Steering();
	}

    // controls balance of the boat
    void Balance()
    {
        if (!m_COM)
        {
            m_COM = new GameObject("COM").transform;

            // COM variable will be the transform the gameobject of this script
            m_COM.SetParent(transform);
        }

        m_COM.position = COM + transform.position;
        GetComponent<Rigidbody>().centerOfMass = m_COM.position;
    }
    
    void Movement()
    {
        //verticalInput = Input.GetAxis("Vertical");
        movementFactor = Mathf.Lerp(movementFactor, verticalInput, Time.deltaTime / movementThreshold);
        transform.Translate(0.0f, 0.0f, movementFactor * speed);
    }

    void Steering()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        steerAngle = steeringWheel.transform.rotation.eulerAngles.z;

        // if the rotation exceeds the 180 rotation meaning it is turning to the right
        if (steeringWheel.transform.rotation.eulerAngles.z > 180)
        {
            // get rotation of the steering wheel
            horizontalInput = (steeringWheel.transform.rotation.eulerAngles.z - 360f) * 0.01f;
        }
        else
        {
            // get rotation of the steering wheel
            horizontalInput = steeringWheel.transform.rotation.eulerAngles.z * 0.01f;
        }


        if (horizontalOutput < maxHorizontalOutput)
        {
            horizontalOutput = horizontalInput + horizontalRate;
        }

        steerFactor = Mathf.Lerp(steerFactor, horizontalOutput * verticalInput, Time.deltaTime / movementThreshold);
        transform.Rotate(0.0f, 2f * steerFactor * steerSpeed, 0.0f);
    }

    public void ForwardMovement()
    {
        // if the max speed hasn't been reached
        if (verticalInput < maxVerticalInput)
        {
            // increment the vertical speed
            verticalInput = verticalInput + verticalRate;
        }
        Movement();
    }
    
    public void ReverseMovement()
    {
        // if the min speed hasn't been reached
        if (verticalInput > -maxVerticalInput)
        {
            // decrement the vertical speed
            verticalInput = verticalInput - verticalRate;
        }
        Movement();
    }

    public void StopMovement()
    {
        // reset the movement speed
        verticalInput = 0f;
        //horizontalInput = 0f;
        Movement();
    }
}
