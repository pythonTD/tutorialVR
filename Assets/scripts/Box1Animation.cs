using CrazyMinnow.SALSA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box1Animation : MonoBehaviour{

    public static bool startBox1 = false;
    //public AudioClip otherSide;

    public static bool liftBoxOne = false;

    private void Update()
    {
        if (startBox1) {
            transform.position = new Vector3(5, 5, 5);
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "VH"){

            //set this to true after the audio ended playing
            //moves the box to trigger the ontriggerexit and run another audio
            startBox1 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "VH")
        {
            liftBoxOne = true;
            //set this to true after the audio ended playing
            //moves the box to trigger the ontriggerexit and run another audio
            //startBox1 = true;
        }
    }


}
