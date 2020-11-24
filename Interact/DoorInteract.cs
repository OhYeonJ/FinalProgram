using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteract : MonoBehaviour {
    //열쇠로 열리는 문 포인트

    public string transferMapName; //이동할 맵의 이름

    private Player player;

    public BoxCollider2D theBound; //바운드 불러오기

    private CameraMovement theCamera; //카메라 불러오기

    public bool isOpen = false; //문 잠긴 상태

    SoundManager sound;

    public string playSound;

    [SerializeField] private ItemType2 itemType2;
    [SerializeField] private Item2 item2;

    private GameObject playerObject;
    private GameObject mainCamera;
    private GameObject dialogue;
    private GameObject inventory;
    private GameObject inventory2;
    private GameObject gameSave;
    private GameObject gameSave2;

    public void Start()
    {
        gameObject.SetActive(true);
        player = FindObjectOfType<Player>();
        sound = FindObjectOfType<SoundManager>();

        playerObject = GameObject.Find("Player");
        mainCamera = GameObject.Find("Main Camera");
        dialogue = GameObject.Find("Dialogue");
        inventory = GameObject.Find("Inventory");
        inventory2 = GameObject.Find("stage2.Inventory");
        gameSave = GameObject.Find("GameSaveManager");
        gameSave2 = GameObject.Find("stage2.GameSaveManager");
    }

    public ItemType2 GetItemType()
    {
        return itemType2;
    }

    public Item2 GetItemInfo()
    {
        return item2;
    }

    public void IsOpen()
    {
        
    }
    

    public void itemActived() //열쇠
    {
        sound.Play(playSound);
        LoadSceneManager.LoadScene(transferMapName);

        if (gameObject.name == "현관문 노드") //현관문 오브젝트에서 실행했으면
        {
            Destroy(playerObject);
            Destroy(mainCamera);
            Destroy(dialogue);

            //stage1 에서 stage2로 넘어갈 때
            inventory.SetActive(false);
            gameSave.SetActive(false);

            //stage2에서 Ending씬으로 넘어갈 때
            inventory2.SetActive(false);
            gameSave2.SetActive(false);

            /*
            //게임 재시작 후 2스테이지로 넘어갔을 때 => 이건 스타트 매니저 쓰기
            if(inventory2 == false && gameSave2 == false)
            {
                inventory2.SetActive(true);
                gameSave2.SetActive(true);
            }
            */

            //Destroy(inventory);
            //Destroy(inventory2);
            //Destroy(gameSave);
            //Destroy(gameSave2);
        }

        if(player != null) //일반 문일 경우
        {
            player.currentMapName = transferMapName;
           
        }

        isOpen = true;
        Destroy(this);
        theCamera.SetBound(theBound);

    }
}
