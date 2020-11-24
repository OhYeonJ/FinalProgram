using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTransferMap : MonoBehaviour {

   //드레스룸 문 열기 이벤트

    public Dialogue dialogue1;
    public Dialogue dialogue2;

    private DialogueManager dm;
    private MoveOrder order;

    SoundManager sound;

    public string playDoorSound;
    public string playScreamSound;


    public GameObject sprit; //선령
    public GameObject enemy1; //악령1
    public GameObject enemy2; //악령2
    public GameObject enemy3; //악령3
    public GameObject enemy4; //악령4
    public GameObject keyItem; //키

    // Use this for initialization
    void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
        order = FindObjectOfType<MoveOrder>();
        sprit.SetActive(false);
        keyItem.SetActive(false);
        sound = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Z)) //임시
            {
                StartCoroutine("DontOpenDoor");
            }
        }
    }

    IEnumerator DontOpenDoor()
    {
        order.NotMove(); 

        sound.Play(playDoorSound);       
        dm.ShowDialogue(dialogue1); 
        yield return new WaitUntil(() => !dm.talking);

        sound.Play(playDoorSound);
        dm.ShowDialogue(dialogue2);
        yield return new WaitUntil(() => !dm.talking);

        sprit.SetActive(true);
        yield return new WaitForSeconds(2f);

        sound.Play(playScreamSound);
        enemy1.SetActive(false); 
        
        yield return new WaitForSeconds(2f);
        enemy2.SetActive(false);
        
        yield return new WaitForSeconds(2f);
        enemy3.SetActive(false);
      
        yield return new WaitForSeconds(2f);
        enemy4.SetActive(false);
       
        yield return new WaitForSeconds(2f);

        sprit.SetActive(false);
        
        yield return new WaitForSeconds(2f);
        sound.Stop(playScreamSound);
        keyItem.SetActive(true);
        yield return new WaitForSeconds(2f);
        Destroy(this);

        order.Move();
        //dm.ShowDialogue(dialogue);
        //yield return new WaitUntil(() => !dm.talking);
    }
}
