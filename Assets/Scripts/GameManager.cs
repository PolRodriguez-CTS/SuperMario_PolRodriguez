using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isPlaying = true;
    public bool isPaused = false;
    private SoundManager _soundManager;
    public GameObject pauseCanvas;
    public GameObject optionsCanvas;
    private int coins = 0;
    public Text coinsText;
    private int goombas = 0;
    public Text goombasText;
    public List<GameObject> enemiesInScreen; 


    void Awake()
    {
        _soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
    }

    void Start()
    {
        coinsText.text= "Coins: " + coins.ToString();
        goombasText.text = "Goombas: " + goombas.ToString();
    }

    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            Pause();
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            foreach(GameObject enemy in enemiesInScreen)
            {
                Enemy enemyScript = enemy.GetComponent<Enemy>();
                enemyScript.Death();
            }
        }
    }

    

    public void Pause()
    {
            if(isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
                _soundManager.PauseBGM();
                pauseCanvas.SetActive(false);
                optionsCanvas.SetActive(false);
                
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

    public void AddCoins()
    {
        coins++;
        //To string cambia el valor a un string (texto)
        coinsText.text = "Coins: " + coins.ToString();
    }

    public void AddGoombas()
    {
        goombas++;
        goombasText.text = "Goombas: " + goombas.ToString();
    }
}
