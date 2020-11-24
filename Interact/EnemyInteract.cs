using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : MonoBehaviour
{

    //아이템으로 적과 상호작용하는 스크립트
    public Dialogue dialogue;

    private DialogueManager dm;
    private MoveOrder order;

    public GameObject enemy;
    public GameObject nextPoint;

    SoundManager sound;
    public string playSound;



    [SerializeField] private ItemType2 itemType2;
    [SerializeField] private Item2 item2;

     public void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
        order = FindObjectOfType<MoveOrder>();
        enemy.SetActive(true);
        nextPoint.SetActive(false);
        sound = FindObjectOfType<SoundManager>();
    }


    public ItemType2 GetItemType()
    {
        return itemType2;
    }

    public Item2 GetItemInfo()
    {
        return item2;
    }

    public void monsterItemActived() //몬스터에게 아이템 썼을 때 트리거
    {
        StartCoroutine(Actived());
    }    

    IEnumerator Actived()
    {
        order.NotMove();

        dm.ShowDialogue(dialogue);
        yield return new WaitUntil(() => !dm.talking);

        sound.Play(playSound);
        enemy.SetActive(false); //몬스터 사라지게
        //yield return new WaitUntil(() => !enemy);

        nextPoint.SetActive(true);

        order.Move();
        yield return new WaitForSeconds(1f);

        enabled = false;
    }
}
