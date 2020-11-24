using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour {

    static public BgmManager instance;

    public AudioClip[] clip; //배경음악

    private AudioSource source;

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

    
    
    void Start () {
        source = GetComponent<AudioSource>();

	}

    public void Play(int playSound)
    {
        source.clip = clip[playSound];
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }
	
}
