using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    //public static ItemDatabase instance;


   

    [SerializeField]
    private ToolTip toolTip;

    public List<Item2> itemDB = new List<Item2>();

    private void Awake()
    {
        toolTip = FindObjectOfType<ToolTip>();
        //instance = this;
    }

    public void ShowToolTip(Item2 _item)
    {
        toolTip.ShowToolTip(_item);
    }

    public void HideToolTip()
    {
        toolTip.HideToolTip();
    }
    
}
