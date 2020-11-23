using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public GameObject inventory;
    public GameObject gameSave;
    

    void Awake()
    {
        inventory = GameObject.Find("Inventory");
        gameSave = GameObject.Find("GameSaveManager");

        inventory.SetActive(true);
        gameSave.SetActive(true);


        //게임 재시작시 인벤토리와 게임 데이터 세이브가 꺼져있으면 다시 키기
        if (inventory.activeSelf == false && gameSave.activeSelf == false)
        {
            inventory.SetActive(true);
            gameSave.SetActive(true);
        }
    }

 
}

