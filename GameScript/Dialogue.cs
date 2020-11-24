using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Dialogue
{
    [TextArea(1,2)]
    public string[] sentences; //문장들을 배열로 만듦
    public Sprite[] dialogueWindows; //대화창
    
}
