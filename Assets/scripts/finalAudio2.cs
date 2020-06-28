using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalAudio2 : MonoBehaviour{

    public static bool area;
    public AudioClip otherSide;
    AudioSource myAudioSource;
    GameObject Answers;


    static public bool activateSecond=false;


    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GameObject.Find("FemaleAvatar").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "VH"){
            myAudioSource.clip = otherSide;
            myAudioSource.Play();
            //area = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "VH"){

            activateSecond = true;
        }

    }

}
