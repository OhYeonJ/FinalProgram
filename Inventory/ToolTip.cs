using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToolTip : MonoBehaviour {

    [SerializeField]
    private GameObject go; //툴팁창

    [SerializeField]
    private Text itemName; //아이템 이름

    [SerializeField]
    private Text itemDes; //아이템 설명

    private void Start()
    {
        //DontDestroyOnLoad(this);
        go.SetActive(false);
    }

    public void ShowToolTip(Item2 _item) //아이템 툴팁 보이게
    {
        go.SetActive(true);

        itemName.text = _item.itemName;
        itemDes.text = _item.itemDescription;
    }

    public void HideToolTip() //아이템 툴팁 안보이게
    {
        go.SetActive(false);
    }


}
