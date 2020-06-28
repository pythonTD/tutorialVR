using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box1UserSpeech : MonoBehaviour
{

    public static bool user1Lift = false;
    static public bool activateSecond = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "USER")
        {
            user1Lift = true;
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "USER")
        {
            //set this to true after the audio ended playing
            activateSecond = true;


        }

    }

}
