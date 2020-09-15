using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

    public GameObject PausePanel, Canvas;
    public AudioSource Music;
    
    

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Pause()
    {
        PausePanel.SetActive(true);

        // Music.volume = 0;
        Music.Pause();
        Time.timeScale = 0;

        Canvas.SetActive(false);
        

    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        // Music.volume = 1;
        Music.Play();
        Time.timeScale = 1;

        Canvas.SetActive(true);
        

    }

    public void BackToMenu()
    {
        Application.LoadLevel("MainMenu");
    }

  

}
