using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    private static DialogueManager instance;
    #region Singleton

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    #endregion

    public Text text;
    public SpriteRenderer rendererDialogueWindow;


    //Dialogue Scipt
    private List<string> listSentences;
    private List<Sprite> listDialogueWindow;

    private int count; //대화 진행 상황 카운트

    public Animator animDialogueWindow;

    //private MoveOrder order;
    private CanvasRenderer canvas;

    public bool talking = false;

    void Start () {
        count = 0; //초기값
        text.text = "";//초기값
        listSentences = new List<string>();
        listDialogueWindow = new List<Sprite>();
        //order = FindObjectOfType<MoveOrder>(); //MoveOrder에서 메서드 가져오기

    }

    public void ShowDialogue(Dialogue dialogue) //문장 보이게 하기
    {
        talking = true;

        //order.NotMove();

        for(int i = 0; i < dialogue.sentences.Length; i++)
        {
            listSentences.Add(dialogue.sentences[i]);
            listDialogueWindow.Add(dialogue.dialogueWindows[i]);              
        }

        if (this != null)
        {
            animDialogueWindow.SetBool("Appear", true);
        }
            //animDialogueWindow.SetBool("Appear", true);

        if (this != null)
        {
            Debug.Log("돌아간다");
            StartCoroutine(StartDialogueCoroutine());

        }

       // else
            //order.Move();//다시 움직이게

    }

    public void ExitDialogue()//대화 종료
    {
        count = 0; //초기값
        text.text = "";//초기값

        listSentences.Clear();
        listDialogueWindow.Clear();

        animDialogueWindow.SetBool("Appear", false);

        talking = false;
        //order.Move();//다시 움직이게
       
    }

    public IEnumerator StartDialogueCoroutine() 
    {
        for (int i =0; i < listSentences[count].Length; i++)
        {
            text.text += listSentences[count][i]; //한 글자씩 출력
            yield return new WaitForSeconds(0.01f);
        }

        

    }
	
	void Update () {

        if(talking)
        {           
            if (Input.GetKeyDown(KeyCode.X))
            {
                count++; //대화 카운트 증가
                text.text = ""; //대화창 초기화 

                if (count != listSentences.Count - 1)
                {
                    StopAllCoroutines();
                    ExitDialogue();
                }
                else
                {
                    Debug.Log("다음 문장 출력");
                    StopAllCoroutines();
                    StartCoroutine(StartDialogueCoroutine());


                }
            }
        }
		
	}
}
