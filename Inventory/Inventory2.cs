using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory2 : MonoBehaviour {

    public static Inventory2 instance;

    #region Singleton

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    #endregion


    [SerializeField]
    public Dialogue dialogueOK; //사용 확인 다이얼로그
    public Dialogue dialogueFail; //사용 확인 다이얼로그
    private DialogueManager theDm;

    SoundManager sound;
    public string useKeySound;
    public string failKeySound;

    public string useItemSound;
    public string failItemSound;


    [SerializeField]
    private Slot[] slots;
    private Slot slot;
    

    public delegate void OnChangeItem(); //대리자 호출
    public OnChangeItem onChangeItem; //아이템이 추가되면 슬롯 ui에도 추가되게끔

    public List<Item2> items = new List<Item2>(); //획득한 아이템을 담을 List
    public List<ItemType2> itemTypeList = new List<ItemType2>(); //획득한 아이템 타입을 담을 List
    

    void Start () {

        theDm = FindObjectOfType<DialogueManager>();
        sound = FindObjectOfType<SoundManager>();
    }
	
	public bool AddItem(Item2 _item,ItemType2 _itemType) //아이템을 추가했는가?
    {
        if(items.Count < 12) //아이템 슬롯 최대 12개 
        {
            items.Add(_item); //items 리스트에 아이템 정보 추가
            itemTypeList.Add(_itemType); //itemType 리스트에 아이템 타입 정보 추가 
            if(onChangeItem != null)
            {
                onChangeItem.Invoke();
            }
            return true; // 아이템을 획득하면 true 반환
        }
        else
        return false; //못먹었으면 false
    }

    public bool ContainItem(ItemType2 _itemType)//아이템 타입을 가지고 있는가?
    {
        if(itemTypeList != null)
            return itemTypeList.Contains(_itemType);
   
        else
            return false;
    }


    /*
    public bool FindedItem(Item2 _item) //아이템 찾기. Item2이 아니라 Inventory인 것 같은데
    {       
        for (int i = 0; i < items.Count; i++) //리스트 훑어보기 items.Count = 12
        {
            if (items[i] == _item) //List의 i번째 아이템이 찾고자 하는 아이템과 같다면...
            {
                return true; //true 반환
            }
        }

        return false; //아이템 없으면 false 반환
    }

    public Item2 FindedItemObject(Item2 _item) //이거시 문제
    {
        for(int i=0;i<items.Count;i++)
        {
            if(items[i] != null) //itemsList의 i번째가 null이 아니고
            {
                //ObjectInteract obInteract = GetComponent<ObjectInteract>(); //ObjectInteract에 있는 필요 아이템 정보 받아옴
                //items[i].itemName = null인 상태...
                if (items[i].itemName =) //i의 정보와 ObjectInteract의 정보가 같다면
                {
                    return items[i];//아이템의 이름을 찾았다!
                }
            }

        }

        //아이템을 찾지 못했다면
        return null; //null값 반환

    }
   
    */

    public void RemoveItem(Item2 _item) //아이템 삭제 메서드
    {
        items.Remove(_item);
        //items.RemoveAt(_index); //아이템 정보 삭제
        onChangeItem.Invoke(); //onChangeItme 호출
    }

    public void RemoveItemType(ItemType2 _itemType2)
    {
        itemTypeList.Remove(_itemType2);
        onChangeItem.Invoke(); //onChangeItme 호출
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FieldItem") //필드에 있는 아이템 콜라이더와 충돌했으면
        {
            if(Input.GetKeyDown(KeyCode.Z)) //z키로 조사하고 아이템 습득 
            {
                FieldItems fieldItems = collision.GetComponent<FieldItems>(); //아이템의 콜라이더 컴포넌트 가져옴
                if (AddItem(fieldItems.GetItem(),fieldItems.GetItemType())) //리스트에 아이템 정보/타입 추가
                {
                    fieldItems.DestroyItem();
                }
            }
        } //필드에 있는 아이템 콜라이더와 충돌했으면

        if (collision.tag == "LockedDoor") //잠긴 문의 콜라이더와 충돌했으면
        {
            if (Input.GetKeyDown(KeyCode.Z)) //z키로 조사하고 문과 상호작용
            {
                DoorInteract doorInteract = collision.GetComponent<DoorInteract>();

                if(doorInteract != null)
                {
                    if (ContainItem(doorInteract.GetItemType()) == true)
                    {
                        sound.Play(useKeySound);
                        //theDm.ShowDialogue(dialogueOK); //열쇠 사용 확인 알림
                        doorInteract.itemActived();

                        slot.ItemUse();
                        RemoveItemType(doorInteract.GetItemType());
                        RemoveItem(doorInteract.GetItemInfo());
                        //Invoke("RemoveItemType(doorInteract.GetItemType())", 1f);
                        //Invoke("RemoveItem(doorInteract.GetItemInfo())", 1f);
                    }

                    else if(ContainItem(doorInteract.GetItemType()) == false)
                    sound.Play(failKeySound);                   
                    theDm.ShowDialogue(dialogueFail); //열쇠 없음을 알림
                }
            }
        } //잠긴 문의 콜라이더와 충돌했으면 / 이건 문제없이 돌아감...

        if (collision.tag == "Enemy") //몬스터 콜라이더와 충돌했으면
        {
            if (Input.GetKeyDown(KeyCode.Z)) //z키로 조사하고 상호작용
            {
                EnemyInteract enemyInteract = collision.GetComponent<EnemyInteract>();

                if (enemyInteract != null) 
                {
                    if (ContainItem(enemyInteract.GetItemType()) == true) //여기부터 오류 발생 enemyInteract가 null이 되나?
                    {
                        sound.Play(useItemSound);
                        //theDm.ShowDialogue(dialogueOK); //아이템 사용 확인 알림 / 코루틴 파괴되었다고 뜸

                        //StartCoroutine(InteractionActived());
                        enemyInteract.monsterItemActived();

                        RemoveItemType(enemyInteract.GetItemType());
                        RemoveItem(enemyInteract.GetItemInfo());

                        StartCoroutine(InteractionActived());

                        
                        //Invoke("enemyInteract.monsterItemActived()",1f); //4초 뒤에 몬스터 오브젝트 삭제
                    }

                    else if (ContainItem(enemyInteract.GetItemType()) == false) //false 경우는 문제가 없음
                        sound.Play(failItemSound);
                        theDm.ShowDialogue(dialogueFail); //아이템 없음을 알림.
                }

                

            }
            
        }

        if (collision.tag == "BlockedItem") //지나갈 수 없는 콜라이더와 충돌했으면
        {
            if (Input.GetKeyDown(KeyCode.Z)) //z키로 조사하고 상호작용
            {
                TutorialInteract tutorialInteract = collision.GetComponent<TutorialInteract>();
                if (tutorialInteract != null)
                {
                    if (ContainItem(tutorialInteract.GetItemType()) == true)
                    {
                        theDm.ShowDialogue(dialogueOK); //아이템 사용 확인 알림
                        RemoveItemType(tutorialInteract.GetItemType());
                        RemoveItem(tutorialInteract.GetItemInfo());
                    }

                    else if (ContainItem(tutorialInteract.GetItemType()) == false) //false 경우는 문제가 없음
                        theDm.ShowDialogue(dialogueFail); //아이템 없음을 알림.
                }
            }
               
        }
    }

    IEnumerator InteractionActived()
    {
        yield return new WaitUntil(() => !theDm.talking);

    }
}
