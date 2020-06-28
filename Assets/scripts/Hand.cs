using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Hand : MonoBehaviour
{

    public SteamVR_Action_Boolean m_GrabAction = null;

    private SteamVR_Behaviour_Pose m_Pose = null;

    private FixedJoint m_Joint = null;

    private Interactable m_CurrentInteractable = null;
    public List<Interactable> m_ContactInteractables = new List<Interactable>();

    public static bool rightTriggerPress, leftTriggerPress;

    string pressCtrl;

    public static bool moveToTask2 = false;
    public static bool box1Speech = false;

    private void Awake(){
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {   //down
        if (m_GrabAction.GetStateDown(m_Pose.inputSource))
        {
            //Debug.Log(m_Pose.inputSource +" trigger down");

            if (m_Pose.inputSource.ToString() == "LeftHand")
            {
                //Debug.Log("LeftHand");
                leftTriggerPress = true;
            }

            if (m_Pose.inputSource.ToString() == "RightHand")
            {
                //Debug.Log("rightHand");
                rightTriggerPress = true;
            }
            PickUp();
        }
        //up
        if (m_GrabAction.GetStateUp(m_Pose.inputSource))
        {
            //Debug.Log(m_Pose.inputSource + " trigger up");
            Drop();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;
        m_ContactInteractables.Add(other.gameObject.GetComponent<Interactable>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;
        m_ContactInteractables.Remove(other.gameObject.GetComponent<Interactable>());
    }

    public void PickUp()
    {
        //get nearest
        m_CurrentInteractable = GetNearestInteractable();

        //null check
        if (!m_CurrentInteractable)
            return;

        //already held
        if (m_CurrentInteractable.m_ActiveHand)
            m_CurrentInteractable.m_ActiveHand.Drop();
        // position
        m_CurrentInteractable.transform.position = transform.position;
        // attach rb to fixed joint
        Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        m_Joint.connectedBody = targetBody;

        //set active hand
        m_CurrentInteractable.m_ActiveHand = this;

        box1Speech = true;
        
    }

    public void Drop()
    {
        //null check
        if (!m_CurrentInteractable)
            return;

        //apply velocity
        Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = m_Pose.GetVelocity();
        targetBody.angularVelocity = m_Pose.GetAngularVelocity();

        // dettach 
        m_Joint.connectedBody = null;

        //clear
        m_CurrentInteractable.m_ActiveHand = null;
        m_CurrentInteractable = null;
        moveToTask2 = true;


    }

    private Interactable GetNearestInteractable() {
        Interactable nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0f;

        foreach (Interactable interactable in m_ContactInteractables)
        {
            distance = (interactable.transform.position - transform.position).sqrMagnitude;
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }
        }


        return nearest; 
    }

}
