using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectChange : MonoBehaviour {

    private Sprite changedItem;
    SoundManager sound;

    public string playSound; 



    void Start () {
        changedItem = gameObject.GetComponent<SpriteRenderer>().sprite;
        sound = FindObjectOfType<SoundManager>();
    }

	
    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.tag == "Player")
        {
            sound.Play(playSound);
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("깨진 거울");
        }             
    }  
}
