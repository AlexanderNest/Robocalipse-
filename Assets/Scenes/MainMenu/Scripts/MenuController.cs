using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public AudioSource Music;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadGame()
    {
        Music.volume = 0;
        Application.LoadLevel("GameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

