using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChasingMonster : MonoBehaviour {

    public GameObject chasing;
    private GameObject player;

    SoundManager sound;

    public string playSound;

    private GameObject playerObject;
    private GameObject mainCamera;
    private GameObject dialogue;
    private GameObject inventory;
    private GameObject gameSave;

    public float speed = 1f;
   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        chasing.SetActive(false);
        sound = FindObjectOfType<SoundManager>();

        playerObject = GameObject.Find("Player");
        mainCamera = GameObject.Find("Main Camera");
        dialogue = GameObject.Find("Dialogue");
        inventory = GameObject.Find("stage2.Inventory");
        gameSave = GameObject.Find("stage2.GameSaveManager");

        sound.Play(playSound);
    }

	void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            //플레이어와 충돌하면 게임오버 화면으로 넘어가게끔           
            SceneManager.LoadScene("GameOver");
            Destroy(playerObject);
            Destroy(mainCamera);
            Destroy(dialogue);

            //인벤토리 클리어 코드 넣기
            inventory.SetActive(false);
            gameSave.SetActive(false);


        }

    }
    //여유 되면 다이얼로그 창도 넣기
}
