using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHPointManager : MonoBehaviour {

    public GameObject point1;
    public GameObject point2;

    void Start()
    {
        point1.SetActive(true); //첫 번째 포인트 활성화된채로 시작
        point2.SetActive(false); //두 번째 포인트 비활성화된채로 시작
        //point3.SetActive(false); //세 번째 포인트 비활성화된채로 시작
    }

    void Update()
    {
        FirstPointActived();

    }

    public void FirstPointActived()
    {
        if (point1 == null) //point1 오브젝트가 파괴된 경우에
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
