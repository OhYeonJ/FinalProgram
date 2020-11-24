using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInteract : MonoBehaviour {

    public static TutorialInteract instance;

    [SerializeField] private ItemType2 itemType2;
    [SerializeField] private Item2 item2;

    public ItemType2 GetItemType()
    {
        return itemType2;
    }

    public Item2 GetItemInfo()
    {
        return item2;
    }

    public void TutorialActived() //열쇠
    {
        gameObject.SetActive(false);
    }
}
