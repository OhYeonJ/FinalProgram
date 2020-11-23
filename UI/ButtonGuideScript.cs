using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGuideScript : MonoBehaviour {

    public GameObject rendererButton; //버튼 스프라이트 불러오기.

    //public Animator animButton; //버튼 애니메이션 불러오기.

    //private bool triggered; //플레이어가 조사 가능 지역에 있는지 여부 

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("버튼!");
            gameObject.SetActive(true);           
        }

        else
        {
            Destroy(rendererButton);
        }
    }

}
