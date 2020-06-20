/*
Simple Sound Manager (c) 2016 Digital Ruby, LLC
http://www.digitalruby.com

Source code may no longer be redistributed in source format. Using this in apps and games is fine.
*/

using UnityEngine;
using UnityEngine.UI;

using RootMotion.FinalIK;
using CrazyMinnow.SALSA;
// Be sure to add this using statement to your scripts
// using DigitalRuby.SoundManagerNamespace

namespace DigitalRuby.SoundManagerNamespace
{
    public class SoundManagerDemo : MonoBehaviour
    {
        public Slider SoundSlider;
        public Slider MusicSlider;
        public InputField SoundCountTextBox;
        public Toggle PersistToggle;

        public AudioSource[] SoundAudioSources;
        //public AudioSource[] MusicAudioSources;

        Animator anim;
        VRIK VRIKscript;
        Salsa3D salsa;

        public GameObject character;
        private bool explanation = true;
        private bool otherSide = true;
        private string hello="Empty";

        string clipName;
        AnimatorClipInfo[] m_CurrentClipInfo;

        private void Start(){
            SoundManager.StopSoundsOnLevelLoad = !PersistToggle.isOn;
            anim = character.GetComponent<Animator>();
            salsa = character.GetComponent<Salsa3D>();
        }

        private void Update(){
            CheckPlayKey();
        }
         private void CheckPlayKey(){
            if (SoundCountTextBox.isFocused){
                return;
            }

            if (DictationScript.userAnswer=="hello" && explanation==true){
                //PlaySound(0);
                salsa.audioSrc = SoundAudioSources[0];
                salsa.Play();
                anim.SetBool("expl", true);
                explanation = false;
            }
            /*
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Box2") && otherSide == true )
            {
                //PlaySound(2);
                salsa.audioSrc = SoundAudioSources[0];
                salsa.Play();
                otherSide = false;
            }
            */
            
        }
        public void SoundVolumeChanged()
        {
            SoundManager.SoundVolume = SoundSlider.value;
        }
        public void MusicVolumeChanged()
        {
            SoundManager.MusicVolume = MusicSlider.value;
        }
        public void PersistToggleChanged(bool isOn)
        {
            SoundManager.StopSoundsOnLevelLoad = !isOn;
        }
        private void PlaySound(int index)
        {
            int count;
            if (!int.TryParse(SoundCountTextBox.text, out count))
            {
                count = 1;
            }
            while (count-- > 0)
            {
                SoundAudioSources[index].PlayOneShotSoundManaged(SoundAudioSources[index].clip);
            }
        }

        /*private void PlayMusic(int index)
        {
            MusicAudioSources[index].PlayLoopingMusicManaged(1.0f, 1.0f, PersistToggle.isOn);
        }
        */
    }
}
