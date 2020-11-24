using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour {


    public string transferMapName; //이동할 맵의 이름

    public BoxCollider2D theBound; //바운드 불러오기

    private CameraMovement theCamera;

    SoundManager sound;

    public string playSound; //n번째 트랙 재생

    private Player player;


	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
        theCamera = FindObjectOfType<CameraMovement>();
        sound = FindObjectOfType<SoundManager>();
    }
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if(Input.GetKeyDown(KeyCode.Z)) //임시
            {
                sound.Play(playSound);              
                player.currentMapName = transferMapName;
                LoadSceneManager.LoadScene(transferMapName);
                theCamera.SetBound(theBound);
            }
            
           
        
        }
    }
}
