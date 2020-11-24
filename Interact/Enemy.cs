using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public GameObject floorEnemy; //신발장 귀신 스프라이트


	void Start () {
        floorEnemy.SetActive(false); //이건 됨.
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player") //외않되
        {
            //isTriggered = true;
            
            StartCoroutine("wait");
        }
       
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        floorEnemy.SetActive(true);
    }

    
 
}
