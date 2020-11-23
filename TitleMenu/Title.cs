using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//타이틀 메뉴 버튼

public class Title : MonoBehaviour {

    public string SceneLoad; //불러올 씬 이름

    SoundManager sound;

    public string playSound;

    void Start()
    {
        sound = FindObjectOfType<SoundManager>();
    }

    public void LoadGame()
    {
        sound.Play(playSound);
        LoadSceneManager.LoadScene(SceneLoad);
        
    }
   
}
