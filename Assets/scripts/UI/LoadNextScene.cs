using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNextScene : MonoBehaviour{


    public static string participantGender;
    public static string chosenSystem;

    Dropdown dropDownGender;

    Dropdown avatarSystem;


    public void LoadA(){

        dropDownGender = GameObject.Find("genderDropdown").GetComponent<Dropdown>();
        participantGender = dropDownGender.captionText.text;
        //Debug.Log(chosenValue);

        SceneManager.LoadScene("Main");
    }

}