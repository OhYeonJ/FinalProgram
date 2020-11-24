using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOption : MonoBehaviour {

    //public SoundManager sound;
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    public void BgmVolum(float volum1)
    {
        audioSource1.volume = volum1;
    }

    public void SoundVolum(float volum2)
    {
        audioSource2.volume = volum2;
    }
}
