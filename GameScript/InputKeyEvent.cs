using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyEvent : MonoBehaviour {

    //일반 트리거 이벤트 스크립트

    public Dialogue dialogue1;
    public Dialogue dialogue2;

    private DialogueManager dm;
    private MoveOrder order;
    private Player player;

    private bool check = false; //다이얼로그 포인트가 실행되었는지 여부 판단

    void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
        order = FindObjectOfType<MoveOrder>();
        player = FindObjectOfType<Player>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!check && Input.GetKey(KeyCode.Z))
        {
            check = true; //두 번 실행되지 않게
            StartCoroutine(EventCoroutine1());
        }
    }

    IEnumerator EventCoroutine1()
    {
        order.NotMove();

        dm.ShowDialogue(dialogue1);
        yield return new WaitUntil(() => !dm.talking); //대화가 끝날때까지 대기했다가 다음 다이얼로그 진행

        dm.ShowDialogue(dialogue2);
        yield return new WaitUntil(() => !dm.talking);

        order.Move();
    }
}
