using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementControllerScript : MonoBehaviour {

    public VoiceController voiceControllerScript;
    public SteeringWheel steeringWheelScript;
    public GameObject achievementUI;
    public float achievActive;
    public bool achievEnabled = false;

	// Use this for initialization
	void Start ()
    {
        achievementUI = GameObject.Find("Achievement_Canvas");
        steeringWheelScript = GameObject.Find("Wheel").GetComponent<SteeringWheel>();
        voiceControllerScript = GameObject.Find("Player").GetComponent<VoiceController>();
        achievementUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // enable achievement if the voice command has been called upon or steering wheel has been held
		if(achievEnabled == false && (steeringWheelScript.isHeld == true || voiceControllerScript.forwardCmd == true
            || voiceControllerScript.reverseCmd == true || voiceControllerScript.stopCmd == true))
        {
            // turn on achievement ui briefly
            achievementUI.SetActive(true);
            achievActive += Time.deltaTime;

            if (achievActive > 5f)
            {
                achievementUI.SetActive(false);
            }
        }
	}
}
