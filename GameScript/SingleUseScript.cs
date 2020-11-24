using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//1회용 스크립트 , 대화가 끝나면 파괴됨.
public class SingleUseScript : MonoBehaviour
{
   
    [SerializeField]
    public Dialogue dialogue;
    private DialogueManager theDm;


    // Use this for initialization
    void Start()
    {
        theDm = FindObjectOfType<DialogueManager>(); 
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player")
        {           
            Invoke("WaitTime", 3f);
            theDm.ShowDialogue(dialogue);     
            Invoke("WaitTime", 10f);
            Destroy(this);
            //gameObject.SetActive(false); //노드 포인트 파괴
        }

        
        


    }
    void WaitTime()
    {
        Debug.Log("출력");
    }


}
