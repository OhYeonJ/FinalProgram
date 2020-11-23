using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGuidTrigger : MonoBehaviour {

    //가이드 버튼 on/off 

    public GameObject guideSprite; //가이드 버튼 오브젝트 가져오기


	// Use this for initialization
	void Start () {
        guideSprite.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //isTriggered = true;
            guideSprite.SetActive(true);
        }

    }

    void OnTriggerExit2D(Collider2D collisoin)
    {
        guideSprite.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
