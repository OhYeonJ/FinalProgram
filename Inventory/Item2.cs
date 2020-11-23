using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ItemType2
{
    Use,//소모품(부적)
    BedRoomKey,//침실 열쇠
    LibraryKey,//서재 열쇠
    DressRoomKey,//드레스룸 열쇠
    ExitDoorKey,//현관문 열쇠
    Quest, //꽃
    Etc//기타 아이템(신문,책) 인벤에서 열람 가능
}

[System.Serializable]
public class Item2
{
    public ItemType2 itemType2;
    public int itemID;
    public string itemName;
    [TextArea]
    public string itemDescription; // 아이템 설명
    public int itemCount; //아이템 소지 개수
    public Sprite itemImage;


    public static bool Use() //아이템 사용 메서드
    {
        bool isUsed = false;
        isUsed = true;

        return isUsed; //아이템 사용 성공 여부 반환하기 위해 bool 반환
    }


}
