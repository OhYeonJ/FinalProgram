using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveManager : MonoBehaviour {

    //씬 이동 후 맵 데이터 저장
    public static int count = 0;
    public int index;

    public static GameSaveManager saveManager;
    private GameObject gameData;

    //public List<GameObject> saveObject = new List<GameObject>();

    private void Awake()
    {
        gameData = GameObject.Find("GameSaveManager");

        index = count;
        count++;
        if (count == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        //게임 재시작 시
        if(gameData.activeSelf == false) // || gameData == null)
        {
            gameData.SetActive(true);
            count = 0;
        }
    }
}
