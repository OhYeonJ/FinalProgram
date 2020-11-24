using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//커스텀 클래스
[System.Serializable]
public class Sounds 
{
    public string name; //효과음 이름

    public AudioClip aC; //wave 파일
    private AudioSource aS; // 사운드 플레이어

    public void SettingSources(AudioSource source)
    {
        aS = source;
        aS.clip = aC;
    }
    public void Play()

    {
        aS.Play();
    }

    public void Stop()
    {
        aS.Stop();
    }

}
