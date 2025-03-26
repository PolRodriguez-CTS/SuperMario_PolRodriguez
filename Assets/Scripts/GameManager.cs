using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlaying = true;
    public bool isPaused = false;
    private SoundManager _soundManager;
    
    void Awake()
    {
        _soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            if(isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
                _soundManager.PauseBGM();
            }
            else
            {
                //Para pausar el tiempo, valor entre 0 y 1. 0(se pausa), 0.5 (mitad de velocidad), 1 (velocidad normal)
                Time.timeScale = 0;
                isPaused = true;
                _soundManager.PauseBGM();
            }
        }
    }
}
