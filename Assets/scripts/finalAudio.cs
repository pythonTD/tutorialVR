using CrazyMinnow.SALSA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalAudio : MonoBehaviour{

    private bool area=false;
    public AudioClip otherSide;
    AudioSource myAudioSource;
    GameObject Answers;
    Salsa3D salsa;

    static public bool activateSecond=false;


    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GameObject.Find("FemaleAvatar").GetComponent<AudioSource>();
        salsa = GameObject.Find("FemaleAvatar").GetComponent<Salsa3D>();

    }

    private void Update()
    {
        if (area) {
            //if (myAudioSource.isPlaying==false) {
            if (salsa.audioSrc.isPlaying==false) {
                transform.position = new Vector3(5, 5, 5);
            }
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "VH"){
            //myAudioSource.clip = otherSide;
            //myAudioSource.Play();
            salsa.SetAudioClip(otherSide);
            salsa.Play();
            area = true;
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "VH")
        {

            activateSecond = true;
        }

    }



    /*
        // Start is called before the first frame update
        void Start(){
            clip6 = Resources.Load<AudioClip>("6");
            myAudioSource = GameObject.Find("FemaleAvatar").GetComponent<AudioSource>();
            Answers = GameObject.Find("Answers");
        }

        // Update is called once per frame
        void Update(){
            Debug.Log(area);
        }

        private void OnTriggerEnter(Collider other){
            if (other.gameObject.tag == "answer"){
                Answers.SetActive(false);

                myAudioSource.clip = clip6;
                myAudioSource.Play();
            }
            area = true;
        }

        */

}
