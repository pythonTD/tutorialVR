using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RootMotion.FinalIK;
using CrazyMinnow.SALSA;

public class BehaviorManager : MonoBehaviour
{
    public AudioClip[] femaleAudios;
    public AudioClip[] maleAudios;

    public AudioClip[] audios;
    AudioSource myAudioSource;

    AnimatorClipInfo[] currentClipInfo;
    string clipName;

    Animator anim;
    VRIK VRIKscript;
    Salsa3D salsa;

    public GameObject FemaleCharacter;
    public GameObject MaleCharacter;

    public GameObject character;

    private bool explanation = true;
    private string hello = "Empty";
    private bool greeting;

    private bool control1;

    private bool box1Routine;
    private bool userBox1Routine;
    private bool userBox1Speech;


    private bool box2Routine;
    private bool userBox2Routine;

    private bool rightTrigger, leftTrigger;

    static public bool ack1;
    static public bool activateSecond;

    bool ack1Status;
    bool ack2Status;

    GameObject box1move;

    bool box1Status;

    bool female;
    bool male;

    float count = 0;


    string speechInput;

    private void Awake()
    {
        if (LoadNextScene.participantGender=="Male") { 
            character = MaleCharacter;
            FemaleCharacter.SetActive(false);
            male = true;
        }

        if (LoadNextScene.participantGender == "Female")
        {
            character = FemaleCharacter;
            MaleCharacter.SetActive(false);
           female = true;
        }

        if (male) {
            audios = maleAudios; 

        }
        if (female)
        {
            audios = femaleAudios;

        }

        anim = character.GetComponent<Animator>();
        myAudioSource = character.GetComponent<AudioSource>();
        salsa = character.GetComponent<Salsa3D>();

        control1 = true;
        rightTrigger = true;
        leftTrigger = true;

        userBox1Routine = true;
        userBox1Speech = true;


        box2Routine = true;

        box1Status = false;

    }


    private void Start(){
        Invoke("vhStartedConv", 5);
        box1move = GameObject.Find("userT1Trigger");

        //if (Box1Animation.liftBoxOne) {
        //    Debug.Log("MIERDA");
        //}
    }


    private void Update()
    {
        CheckPlayKey();

        speechInput = DictationScript.ResultedText;
        Debug.Log(speechInput);

    }
    private void CheckPlayKey()
    {

    if (DictationScript.ResultedText == "hello" && explanation == true || greeting == true && explanation == true)
        {   //this speech will end up with press trigger
            salsa.SetAudioClip(audios[0]);
            salsa.Play();
            explanation = false;
        }
        
    
        if (rightTrigger == true && Hand.rightTriggerPress == true)
        {
            Debug.Log("rightTrigger");
            salsa.SetAudioClip(audios[2]);
            salsa.Play();
            anim.SetBool("leftCtrl", true);
            rightTrigger = false;

        }
        

        //after they press the left hand trigger, she goes to the box        
        if (leftTrigger == true && Hand.leftTriggerPress == true)
        {
            Debug.Log("leftTrigger");
            salsa.SetAudioClip(audios[3]);
            salsa.Play();
            anim.SetBool("walk", true);
            leftTrigger = false;
            box1Routine = true;
        }
        
        if (box1Routine == true)
        {       
            //ack activates the first path animation. to the first box. also switches from anim controller to vrik
            //the script that gets activated is pathAnimation.cs
            ack1 = true;
            box1Routine = false;
        }


        if (userBox1Routine == true  && Box1Animation.liftBoxOne) {
            salsa.SetAudioClip(audios[4]);
            salsa.Play();
            userBox1Routine = false;

        }


        if (box2Routine ==true && speechInput == "ready" || box2Routine == true && speechInput == "finished"
            || box2Routine == true && speechInput == "comfortable" || box2Routine == true && speechInput == "I'm ready") {
            salsa.SetAudioClip(audios[5]);
            salsa.Play();
            activateSecond = true;
            box2Routine = false;
        }





    }

    private bool vhStartedConv(){
        return greeting=true;
    }

}
