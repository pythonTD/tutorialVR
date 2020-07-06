using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;


public class taskPhaseManager : MonoBehaviour{
    static public bool ack1;
    static public bool ack2;

    public bool ack1Status;
    public bool ack2Status;

    public GameObject agent;
    Animator animComponent;

    string clipName;
    AnimatorClipInfo[] m_CurrentClipInfo;


    private void Start()
    {

        agent = BehaviorManager.character;


        animComponent = agent.GetComponent<Animator>();

        m_CurrentClipInfo = animComponent.GetCurrentAnimatorClipInfo(0);
    }


    // Update is called once per frame
    void Update()
    {
        ack2 = BehaviorManager.activateSecond;

        if (ack2)
        {
            ack1 = false;
            agent.GetComponent<pathAnimation2>().enabled = true;
            agent.GetComponent<pathAnimation>().enabled = false;
        }
     }
}
