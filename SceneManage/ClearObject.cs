using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearObject : MonoBehaviour {

    //스테이지 전환 시에 오브젝트 클리어 필요
    public string transferMapName; //이동할 맵의 이름

   // public BoxCollider2D theBound; //바운드 불러오기

  
    private GameObject playerObject;
    private GameObject mainCamera;
    private GameObject dialogue;
    private GameObject inventory;

    void Start()
    {
        playerObject = GameObject.Find("Player");
        mainCamera = GameObject.Find("Main Camera");
        dialogue = GameObject.Find("Dialogue");
        inventory = GameObject.Find("Inventory");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Z)) //임시
            {
                //타이틀 메뉴 불러오고 플레이어 오브젝트 & 메인 카메라 & 인벤토리 모두 파괴
                LoadSceneManager.LoadScene(transferMapName);
                Destroy(playerObject);
                Destroy(mainCamera);
                Destroy(dialogue);
                Destroy(inventory);
            }



        }
    }
}
