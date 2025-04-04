using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
     private float delay = 6;
   public void Play()
   {
        SceneManager.LoadScene(1);
   }

   public void Exit()
   {
        Application.Quit();
   }

   public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
          StartCoroutine(WaitAndLoad());
    }

    public IEnumerator WaitAndLoad()
    {
          yield return new WaitForSeconds (delay);
          SceneManager.LoadScene(2);
    }
}
