using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour {

    //Quit 버튼 눌렀을 때 게임 종료

	public void ExitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Quit 버튼 누르면 유니티 에디터도 멈추게끔
#else
        Application.Quit(); //게임 종료
#endif
    }
}
