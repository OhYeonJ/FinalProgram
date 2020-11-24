using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    [SerializeField]
    public Dialogue dialogue;
    private DialogueManager theDm;
    private MoveOrder order;

    public GameObject goEnemey;

    private GameObject playerObject;
    private GameObject mainCamera;
    private GameObject dialogue2;
    private GameObject inventory;
    private GameObject gameSave;

    SoundManager sound;

    public string playSound; 

    // Use this for initialization
    void Start()
    {
        goEnemey.SetActive(false);
        theDm = FindObjectOfType<DialogueManager>();
        order = FindObjectOfType<MoveOrder>();

        playerObject = GameObject.Find("Player");
        mainCamera = GameObject.Find("Main Camera");
        dialogue2 = GameObject.Find("Dialogue");
        inventory = GameObject.Find("Inventory");
        gameSave = GameObject.Find("GameSaveManager");

        sound = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {

                StartCoroutine(WaitTime2());

            }
        }



        //this.GetComponent<Collider2D>().enabled = false;
    }

    IEnumerator WaitTime2()
    {

        order.NotMove();

        goEnemey.SetActive(true);
        yield return new WaitForSeconds(1f);
        sound.Play(playSound);
        theDm.ShowDialogue(dialogue);
        yield return new WaitUntil(() => !theDm.talking);

        SceneManager.LoadScene("GameOver");

        Destroy(playerObject);
        Destroy(mainCamera);
        Destroy(dialogue2);

        //인벤토리 클리어 코드 넣기
        inventory.SetActive(false);
        gameSave.SetActive(false);
    }

}
