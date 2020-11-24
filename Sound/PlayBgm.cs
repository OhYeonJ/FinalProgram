using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBgm : MonoBehaviour {

    BgmManager Bgm;

    public int playSound; //n번째 트랙 재생

	
	void Start () {
        Bgm = FindObjectOfType<BgmManager>();

        
        Bgm.Play(playSound);
        //gameObject.SetActive(false);
    }
	
	
}
