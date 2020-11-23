using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage2Manager : MonoBehaviour
{
    //씬 이동 후 맵 데이터 저장
    public static int count = 0;
    public int index;

    public static GameSaveManager saveManager;

    //public List<GameObject> saveObject = new List<GameObject>();

    private void Awake()
    {
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
    }
}

