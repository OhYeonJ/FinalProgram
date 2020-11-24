using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopoutEnemy : MonoBehaviour {


    public GameObject popOutEnemy; //튀어나오는 귀신 애니메이션

    SoundManager sound;

    public string playSound; 


    void Start()
    {
        sound = FindObjectOfType<SoundManager>();
        popOutEnemy.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") 
        {          
            popOutEnemy.SetActive(true);
            StartCoroutine("wait");
        }
    }

    IEnumerator wait()
    {
        sound.Play(playSound);
        yield return new WaitForSeconds(3f);
        Destroy(popOutEnemy);
        yield return new WaitForSeconds(5f);
        enabled = false;
    }
}
