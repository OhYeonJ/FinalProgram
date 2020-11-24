using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    private AudioSource aS; // 사운드 플레이어
    static public SoundManager instance;

   [SerializeField]
    public Sounds[] sound;
    

    private void Awake() //싱글톤
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

    }

    void Start()
    {
        aS = GetComponent<AudioSource>();
        for (int i =0; i < sound.Length; i++)
        {
            GameObject soundObject = new GameObject("사운드 파일 이름: " + i + "." + sound[i].name);
            sound[i].SettingSources(soundObject.AddComponent<AudioSource>());
            soundObject.transform.SetParent(transform);

        }

    }

    public void Play(string soundName)
    {
        for (int i = 0; i < sound.Length; i++)
        {
           if(soundName == sound[i].name)
            {
                sound[i].Play();
                return;
            }
        }
    }

    public void Stop(string soundName)
    {
        for (int i = 0; i < sound.Length; i++)
        {
            if (soundName == sound[i].name)
            {
                sound[i].Stop();
                return;
            }
        }
    }

}
