using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour {

    public GameObject credit;
    public GameObject close;
    

    void Start()
    {
       
        credit.SetActive(false);
        close.SetActive(false);
    }

	public void CreditButton()
    {
     
        credit.SetActive(true);
        close.SetActive(true);
    }

    public void CloseButton()
    {
       
        credit.SetActive(false);
        close.SetActive(false);
    }
}
