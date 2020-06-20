using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;


public class taskPhaseManager : MonoBehaviour{
    static public bool ack1;
    static public bool ack2;

    public bool ack1Status;
    public bool ack2Status;

    public GameObject characterMoving;
    Animator animComponent;

    string clipName;
    AnimatorClipInfo[] m_CurrentClipInfo;

    private void Start()
    {
        animComponent = characterMoving.GetComponent<Animator>();
        //Fetch the current Animation clip information for the base layer
        m_CurrentClipInfo = animComponent.GetCurrentAnimatorClipInfo(0);
    }


    // Update is called once per frame
    void Update()
    {
        //ack1 = ack1Status;
        ack2 = finalAudio.activateSecond;

        //clipName = m_CurrentClipInfo[0].clip.name;


        if (animComponent.GetCurrentAnimatorStateInfo(0).IsName("Box1")) {
            ack1 = true;

        }
        if (ack2)
        {
            ack1 = false;
            //characterMoving.GetComponent<VRIK>().enabled=false;
            characterMoving.GetComponent<pathAnimation2>().enabled = true;
            characterMoving.GetComponent<pathAnimation>().enabled = false;

        }
        

    }
}
