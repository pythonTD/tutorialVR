using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RootMotion.FinalIK;
using CrazyMinnow.SALSA;

public class BehaviorManager : MonoBehaviour
{
    public AudioClip[] audios;
    AudioSource myAudioSource;

    AnimatorClipInfo[] currentClipInfo;
    string clipName;

    Animator anim;
    VRIK VRIKscript;
    Salsa3D salsa;

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

    float count = 0;


    string speechInput;

    private void Awake()
    {
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
        Invoke("vhStartedConv", 10);

        box1move = GameObject.Find("userT1Trigger");

        if (Box1Animation.liftBoxOne) {
            Debug.Log("MIERDA");

        }
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
            || box2Routine == true && speechInput == "comfortable") {
            salsa.SetAudioClip(audios[5]);
            salsa.Play();
            activateSecond = true;
            box2Routine = false;
        }





        /*
        if (userBox1Routine == true && box1UserSpeech.user1Lift == true)
        {
            salsa.SetAudioClip(audios[4]);
            salsa.Play();
            userBox1Routine = false;

        }

        //ask if the user is ok. if answe is yes. then move to second box. do the same for second box.
        
        
        
        
        
        
        /*
         * 
         *         //play right trigger audio
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("control1") && control1 == true)
        {
            salsa.SetAudioClip(audios[1]);
            salsa.Play();
            control1 = false;
        }
        if (userBox1Speech == true && Hand.box1Speech == true)
        {
            salsa.SetAudioClip(audios[5]);
            salsa.Play();
            userBox1Speech = false;
        }

        if (userBox2Routine == true && Hand.moveToTask2 == true)
        {
            salsa.SetAudioClip(audios[6]);
            salsa.Play();
            userBox2Routine = false;
            box1move.transform.position = new Vector3(10f,10f,10f);
        }
        
        */


    }

    private bool vhStartedConv(){
        return greeting=true;
    }

}
