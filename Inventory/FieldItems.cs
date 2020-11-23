using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour {

    public Item2 item2;
    public ItemType2 itemType2;
    public SpriteRenderer image;

    private SoundManager soundManager;
    public string getSound;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    public void SetItem(Item2 _item)
    {
        item2.itemID = _item.itemID; //itemID = 아이템 이미지 파일의 이름과 같음.
        item2.itemName = _item.itemName;
        item2.itemDescription = _item.itemDescription;
        item2.itemType2 = _item.itemType2;
        item2.itemCount = _item.itemCount;

        image.sprite = _item.itemImage;

    }
    public Item2 GetItem()
    {
        return item2;
    }

    public ItemType2 GetItemType()
    {
        return itemType2;
    }

    public void DestroyItem()
    {
        soundManager.Play(getSound);
        StartCoroutine(WaitTime());
        Destroy(gameObject);
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1f);
    }
}
