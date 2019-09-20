using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAudioControllerScript : MonoBehaviour {

    public GameObject sun;
    public AudioClip shipWavesDayAudioClip;
    public AudioClip shipWavesNightAudioClip;
    public new AudioSource audio;
    public bool playShipAudio;

	// Use this for initialization
	void Start ()
    {
        sun = GameObject.Find("Sun");
        audio = GetComponent<AudioSource>();

    }

    void Update()
    {
		if (playShipAudio == true)
        {
            if (sun.transform.position.y < 0 && audio.clip != shipWavesNightAudioClip)
            {
                audio.clip = shipWavesNightAudioClip;
                audio.Play();
            }
            else if (sun.transform.position.y > 0 && audio.clip != shipWavesDayAudioClip)
            {
                audio.clip = shipWavesDayAudioClip;
                audio.Play();
            }
        }

    }
}
