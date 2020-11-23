using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {
    private static InventoryUI instance;

    #region Singleton
    private void Awake()
    {
        //싱글톤
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
    #endregion Singleton


    Inventory2 inven;

    public GameObject inventoryPanel;
    bool activeInventory = false; //인벤토리 안보이는 상태로 시작

    public Slot[] slots;
    public Transform slotHolder;

    private Button button; //버튼 기능 활성화 유지 위해...

    SoundManager sound;

    public string playSound; //n번째 트랙 재생

    private void Start()
    {
        //DontDestroyOnLoad();
        inven = Inventory2.instance;
        button = FindObjectOfType<Slot>().GetComponent<Button>();
        DontDestroyOnLoad(button); //버튼 기능 파괴 방지
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inven.onChangeItem += RedrawSlotUI;
        inventoryPanel.SetActive(activeInventory);
        sound = FindObjectOfType<SoundManager>();

    }

    private void SlotChange(int val)
    {
        for(int i= 0; i< slots.Length; i++)
        {
            slots[i].slotnum = i;
            if(i<12) //12 = 슬롯 개수
            {
                slots[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            sound.Play(playSound);
            //Debug.Log("인벤토리 오픈!");
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);

            /*
            if (activeInventory == true) //인벤토리가 활성화 돼있는 상태라면
            {
                Time.timeScale = 0; //게임 내 시간 멈추게
            }

            else //인벤토리 비활성화 상태라면
            {
                Time.timeScale = 1f; //시간 흘러가게
            }
            */
        }

       
    }

    void RedrawSlotUI()
    {
        for(int i =0;i<slots.Length;i++)
        {
            slots[i].RemoveSlot(); //슬롯 배열 길이만큼 초기화
        }

        for(int i = 0;i<inven.items.Count; i++)
        {
            slots[i].item = inven.items[i]; //아이템 채워넣기
            slots[i].UpdateSlotUI();
        }
    }
}
