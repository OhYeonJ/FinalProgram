using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    SoundManager sound;

    public string playSound; 


    void Start()
    {
        sound = FindObjectOfType<SoundManager>();
    }

    public void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.name == "Player") //외않되
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                sound.Play(playSound);
            }
        }
    }
}
