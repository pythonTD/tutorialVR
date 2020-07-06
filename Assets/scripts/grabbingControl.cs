using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class grabbingControl : MonoBehaviour
{
    public SteamVR_Input_Sources leftHandFist = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources rightHandFist = SteamVR_Input_Sources.RightHand;

    //left hand

    public Transform LeftHand;

    public Transform LeftHandIndex1;
    public Transform LeftHandIndex2;
    public Transform LeftHandIndex3;

    public Transform LeftHandMiddle1;
    public Transform LeftHandMiddle2;
    public Transform LeftHandMiddle3;

    public Transform LeftHandPinky1;
    public Transform LeftHandPinky2;
    public Transform LeftHandPinky3;

    public Transform LeftHandRing1;
    public Transform LeftHandRing2;
    public Transform LeftHandRing3;

    public Transform LeftHandThumb1;
    public Transform LeftHandThumb2;
    public Transform LeftHandThumb3;

    //right hand
    public Transform RightHand;
    public Transform RightHandIndex1;
    public Transform RightHandIndex2;
    public Transform RightHandIndex3;

    public Transform RightHandMiddle1;
    public Transform RightHandMiddle2;
    public Transform RightHandMiddle3;

    public Transform RightHandPinky1;
    public Transform RightHandPinky2;
    public Transform RightHandPinky3;

    public Transform RightHandRing1;
    public Transform RightHandRing2;
    public Transform RightHandRing3;

    public Transform RightHandThumb1;
    public Transform RightHandThumb2;
    public Transform RightHandThumb3;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SteamVR_Actions._default.Squeeze.GetAxis(rightHandFist).ToString());
        if (SteamVR_Actions._default.Squeeze.GetAxis(rightHandFist) > 0.1f)
        {
            rightFist();
        }
        else
        {
            defaultRightPosition();
        }

        if (SteamVR_Actions._default.Squeeze.GetAxis(leftHandFist) > 0.1f)
        {
            leftFist();
        }

        else {
            defaultLeftPosition();
        }
    }

    void leftFist()
    {
        //left arm
        LeftHandIndex1.transform.localEulerAngles = new Vector3(42f, 0f, 0f);
        LeftHandIndex2.transform.localEulerAngles = new Vector3(32f, 0f, 0f);
        LeftHandIndex3.transform.localEulerAngles = new Vector3(39f, 0f, 0f);

        LeftHandMiddle1.transform.localEulerAngles = new Vector3(26f, 0f, 0f);
        LeftHandMiddle2.transform.localEulerAngles = new Vector3(45f, 0f, 0f);
        LeftHandMiddle3.transform.localEulerAngles = new Vector3(35f, 0f, 0f);


        LeftHandPinky1.transform.localEulerAngles = new Vector3(30f, 0f, 0f);
        LeftHandPinky2.transform.localEulerAngles = new Vector3(38f, 0f, 0f);


        LeftHandRing1.transform.localEulerAngles = new Vector3(18f, 0f, 0f);
        LeftHandRing2.transform.localEulerAngles = new Vector3(35f, 0f, 0f);
        LeftHandRing3.transform.localEulerAngles = new Vector3(42f, 0f, 0f);

        LeftHandThumb2.transform.localEulerAngles = new Vector3(0f, 0f, 20f);
    }

    void rightFist()
    {
        //right arm
        RightHandIndex1.transform.localEulerAngles = new Vector3(42f, 0f, 0f);
        RightHandIndex2.transform.localEulerAngles = new Vector3(32f, 0f, 0f);
        RightHandIndex3.transform.localEulerAngles = new Vector3(39f, 0f, 0f);

        RightHandMiddle1.transform.localEulerAngles = new Vector3(26f, 0f, 0f);
        RightHandMiddle2.transform.localEulerAngles = new Vector3(45f, 0f, 0f);
        RightHandMiddle3.transform.localEulerAngles = new Vector3(35f, 0f, 0f);


        RightHandPinky1.transform.localEulerAngles = new Vector3(30f, 0f, 0f);
        RightHandPinky2.transform.localEulerAngles = new Vector3(38f, 0f, 0f);


        RightHandRing1.transform.localEulerAngles = new Vector3(18f, 0f, 0f);
        RightHandRing2.transform.localEulerAngles = new Vector3(35f, 0f, 0f);
        RightHandRing3.transform.localEulerAngles = new Vector3(42f, 0f, 0f);

        RightHandThumb2.transform.localEulerAngles = new Vector3(0f, 0f, -20f);
    }

    void defaultLeftPosition()
    {

        //left arm
        LeftHandIndex1.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        LeftHandIndex2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        LeftHandIndex3.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

        LeftHandMiddle1.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        LeftHandMiddle2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        LeftHandMiddle3.transform.localEulerAngles = new Vector3(0f, 0f, 0f);


        LeftHandPinky1.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        LeftHandPinky2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);


        LeftHandRing1.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        LeftHandRing2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        LeftHandRing3.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

        LeftHandThumb2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        LeftHandThumb3.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
    }
    void defaultRightPosition()
    {
        //right arm
        RightHandIndex1.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        RightHandIndex2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        RightHandIndex3.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

        RightHandMiddle1.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        RightHandMiddle2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        RightHandMiddle3.transform.localEulerAngles = new Vector3(0f, 0f, 0f);


        RightHandPinky1.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        RightHandPinky2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);


        RightHandRing1.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        RightHandRing2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        RightHandRing3.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

        RightHandThumb2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        RightHandThumb3.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
    }
}
