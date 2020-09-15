using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerScript : MonoBehaviour
{
  
    void Start()
    {
       
        Handheld.PlayFullScreenMovie("Trailer.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
    }

    

    public void toNextScene()
    {
        Application.LoadLevel("MainMenu");
    }
}
