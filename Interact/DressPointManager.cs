using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressPointManager : MonoBehaviour {

    public GameObject point1;
    public GameObject point2;
    private EventTransferMap em;

    void Start()
    {
        point1.SetActive(true); //첫 번째 포인트 활성화된채로 시작
        em = point1.GetComponent<EventTransferMap>();
        point2.SetActive(false); //두 번째 포인트 비활성화된채로 시작
        //point3.SetActive(false); //세 번째 포인트 비활성화된채로 시작
    }

    void Update()
    {
        FirstPointActived();

    }

    public void FirstPointActived()
    {
        if (em == null) //point1 오브젝트가 비활성화된 경우에
        {
            StartCoroutine(EventPoint());
            point2.SetActive(true);
        }
    }


    IEnumerator EventPoint()
    {
        yield return new WaitForSeconds(5f);
    }
}
