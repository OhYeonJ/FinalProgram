using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPoint : MonoBehaviour {


    private CameraMovement theCamera; //카메라 객체 불러오기
    public BoxCollider2D theBound; //바운드 불러오기
    public MoveOrder order;

    public Transform target; 
    
    private Player thePlayer; //플레이어 스크립트 불러오기
    private GameObject playerObject; //플레이어 오브젝트 불러오기

    public string startPoint; //맵을 이동했을 때 플레이어가 시작할 위치

    void Awake()
    {
        theCamera = FindObjectOfType<CameraMovement>(); //CameraMovement 스크립트 가져오기       
        playerObject = GameObject.Find("Player");
        thePlayer = FindObjectOfType<Player>(); //Player 스크립트 가져오기 
        target = thePlayer.transform;

        order = FindObjectOfType<MoveOrder>();
        order.Move();//다시 움직이게
        theCamera.SetBound(theBound);



        if (startPoint == thePlayer.currentMapName)
        {
            theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);//Main 카메라의 위치를 시작 포인트로 이동
            thePlayer.transform.position = transform.position; //플레이어의 위치를 시작 포인트로 이동
            playerObject.transform.position = transform.position;

        }
    }

}
