using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{public void PlayGame()
    {
        Debug.Log("dasd");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }

   public void Update()
   {
      
   }

   public void ExitGame()
    {
        Debug.Log("gameover");
        Application.Quit();
    }
    


}