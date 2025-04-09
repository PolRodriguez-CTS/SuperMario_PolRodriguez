using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
     private float delay;
     //public float delay = 7;

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
          SoundManager _soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
          PlayerControl _playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
          //delay = _playerScript.deathSFX.length;
          delay = _soundManager._gameOver.length + _playerScript.deathSFX.length;
          yield return new WaitForSeconds (delay);
          SceneManager.LoadScene(2);
    }
}