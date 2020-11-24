using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {
    private static GameScript instance;


    [SerializeField]
    public Dialogue dialogue;
    private DialogueManager theDm;


	// Use this for initialization
	void Start () {
        theDm = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	private void OnTriggerEnter2D(Collider2D collision)
    {
        
		if(collision.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {             
                theDm.ShowDialogue(dialogue);
                StartCoroutine(WaitTime()); //대화 스크립트 끝날 때까지 기다렸다가 콜라이더 박스 삭제

            }
        }
        
        
        
        //this.GetComponent<Collider2D>().enabled = false;
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this);
        //enabled = false; //스크립트 비활성화
    }
}
