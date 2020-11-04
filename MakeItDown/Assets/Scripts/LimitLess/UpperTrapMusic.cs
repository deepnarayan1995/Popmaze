using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperTrapMusic : MonoBehaviour
{

    public AllSoundFx Sound;

    public AudioClip upperTrapBlade;

    public AudioSource iAudio;

    public void playBladeDown()
    {
        if(Sound.isSoundOn)
        {
            iAudio.volume = 0.2f;
            iAudio.PlayOneShot(upperTrapBlade);
        }        
    }


}
