using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOrder : MonoBehaviour {

    public static MoveOrder instance;

  
    private Player player; //이벤트 도중에 키 입력 방지
    //private List<CameraMovement> characters;


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        player = FindObjectOfType<Player>(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NotMove()
    {
        player.notMove = true;
    }

    public void Move()
    {
        player.notMove = false;
    }
}
