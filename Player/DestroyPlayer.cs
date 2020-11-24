using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour {
    //튜토리얼 후 남아있는 플레이어 오브젝트 삭제

    public GameObject player;

    public void Start()
    {
        GameObject.Find("Player");
    }

	public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Z)) //임시
            {
                Destroy(player);
            }
        }
    }
	
}
