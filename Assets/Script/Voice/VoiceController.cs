using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;
using System;

public class VoiceController : MonoBehaviour {

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public GameObject colonialShip;
    public BoatControllerScript boatController;
    public GameObject shipAudio;
    public ShipAudioControllerScript shipAudioController;

    public bool forwardCmd = false;
    public bool reverseCmd = false;
    public bool stopCmd = false;

    private void Awake()
    {
        colonialShip = GameObject.Find("ColonialShip");
        boatController = colonialShip.GetComponent<BoatControllerScript>();
        shipAudio = GameObject.Find("Audio_Ship");
        shipAudioController = shipAudio.GetComponent<ShipAudioControllerScript>();
    }

    // Use this for initialization
    void Start ()
    {
        // add a set of 'actions' for each specific word spoken
        actions.Add("forward", Forward);
        actions.Add("reverse", Reverse);
        actions.Add("stop", Stop);
        actions.Add("fire", Fire);

        // takes a string of key words and detects if it's listed in the array
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());

        // when the word is recognized trigger the event
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;

        // loop
        keywordRecognizer.Start();
    }
	
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        // display word spoken in console
        //Debug.Log(speech.text);

        // invoke the methods listed in the array
        actions[speech.text].Invoke();
    }


    private void Forward()
    {
        shipAudioController.playShipAudio = true;
        forwardCmd = true;
        boatController.ForwardMovement();
    }

    private void Reverse()
    {
        shipAudioController.playShipAudio = true;
        reverseCmd = true;
        boatController.ReverseMovement();
    }

    private void Stop()
    {
        stopCmd = true;
        boatController.StopMovement();
    }

    private void Fire()
    {
        // boatController.FireCannon();
    }
}
