using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    
    //Start 버튼 누르고 게임 시작시.. 필요가 있을까?
    //삭제할 스크립트.
    /*
    public BoxCollider2D theBound; //바운드 불러오기

    private CameraMovement theCamera;

    public string startPointName;

    private Player player;

    private GameObject playerObject;

    public Transform target;
    */
    public GameObject startGameButton; //스타트 버튼 

    void Awake()
    {   /*
        playerObject = GameObject.Find("Player");
        player = FindObjectOfType<Player>();
        theCamera = FindObjectOfType<CameraMovement>();
        //theCamera.SetBound(theBound);
        target = player.transform;

      
        if (startPointName == player.currentMapName)
        {
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);//Main 카메라의 위치를 시작 포인트로 이동
            player.transform.position = transform.position; //플레이어의 위치를 시작 포인트로 이동
            playerObject.transform.position = transform.position;
            theCamera.SetBound(theBound);
        }
       */
    } 
    

    public void StartGame() //게임 진입 버튼
    {
    
        LoadSceneManager.LoadScene("stage1.Livingroom");
        //theCamera.SetBound(theBound);
    }

}
