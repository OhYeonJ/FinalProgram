using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour {
    SoundManager sound;

    public string playSound; //n번째 트랙 재생

    public BoxCollider2D thisCollider;

    void Start()
    {
        sound = FindObjectOfType<SoundManager>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") //외않되
        {           
            sound.Play(playSound);
            Destroy(thisCollider);
        }
    }
}
