using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    private static Slot instance;

    public int slotnum;
    public Item2 item;
    public ItemType2 itemType;
    public Image itemIcon;
    public ItemDatabase itemDB;
    public string itemName; //아이템 이름


    public void Start()
    {       
        itemDB = FindObjectOfType<ItemDatabase>();
        DontDestroyOnLoad(itemDB);
    }

    public void UpdateSlotUI() //슬롯 UI 업데이트
    {
        itemType = item.itemType2; //아이템 타입 가져오기 / 추가된 코드
        itemName = item.itemName; //아이템 이름 가져오기
        itemIcon.sprite = item.itemImage; //아이템 이미지 스프라이트 가져오기 
        itemIcon.gameObject.SetActive(true); //itemIcon 오브젝트 활성화      
    }

    public void RemoveSlot() //슬롯 삭제
    {
        item = null; //아이템 정보 삭제
        itemName = null; //아이템 이름 삭제
        itemIcon.gameObject.SetActive(false); //null값?
    }

    public void OnPointerEnter(PointerEventData eventData) //마우스가 아이템박스 영역 안에 들어왔으면 아이템 사용했을 때 삭제
    {
        if(item != null)
        itemDB.ShowToolTip(item);
    }

    public void OnPointerExit(PointerEventData eventData) //마우스가 아이템 영역에서 벗어났을 때
    {
        itemDB.HideToolTip();
    }

    public void ItemUse() //아이템 사용 메서드
    {      
        bool isUse = Item2.Use();
        Inventory2.instance.RemoveItem(item);
        Inventory2.instance.RemoveItemType(itemType);
    }       

}
