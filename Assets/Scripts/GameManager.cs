using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPlaying = true;
    public bool isPaused = false;
    private SoundManager _soundManager;
    public GameObject pauseCanvas;
    
    void Awake()
    {
        _soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
    }

    void Update()
    {
        Pause();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        if(Input.GetButtonDown("Pause"))
        {
            if(isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
                _soundManager.PauseBGM();
                pauseCanvas.SetActive(false);
            }
            else
            {
                //Para pausar el tiempo, valor entre 0 y 1. 0(se pausa), 0.5 (mitad de velocidad), 1 (velocidad normal)
                Time.timeScale = 0;
                isPaused = true;
                _soundManager.PauseBGM();
                pauseCanvas.SetActive(true);
            }
        }
    }
}
