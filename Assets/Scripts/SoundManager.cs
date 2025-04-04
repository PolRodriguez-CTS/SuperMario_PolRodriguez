using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    private GameManager _gameManager;
    private Flagpole _flagpole;
    public AudioClip _bgm;
    public AudioClip _gameOver;
    public AudioClip _victory;
    public float delay = 3;

    public float delayVictoryBGM = 2;
    public float timer;
    //Varaible comprobar contador ha terminado --> private bool timerFinsished = false;
    
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _flagpole = GameObject.Find("Flag").GetComponent<Flagpole>();
    }

    void Start()
    {
        PlayBGM();
    }

    void Update()
    {
        /*if(!_gameManager.isPlaying && !timerFinsished)
        {
                 DeathBGM();
        }*/
     
    }

    void PlayBGM()
    {
        _audioSource.clip = _bgm;
        _audioSource.loop = true;
        _audioSource.Play();
    }

    //Esta función hace lo mismo que la corutina de abajo, solo que es mejor la corutina para el delay, por tanto la variable booleana hasWinned no sirve si usamos la booleana
/*
    public void VictoryBGM()
    {
        if(_flagpole.hasWinned)
        {
          _audioSource.clip = _victory;
          _audioSource.Play();
        }    
    }
*/
    public IEnumerator VictoriaBGM()
    {
        _audioSource.clip = _victory;
        yield return new WaitForSeconds(delayVictoryBGM);
        _audioSource.PlayOneShot(_victory);
    }


    public void PauseBGM()
    {
        if(_gameManager.isPaused)
        {
            _audioSource.Pause();
        }
        else
        {
            _audioSource.Play();
        }
    }

    /*public void DeathBGM()
    {
        _audioSource.Stop();
        
         timer += Time.deltaTime;

        if(timer >= delay)
        {
            timerFinsished = true;
            _audioSource.PlayOneShot(_gameOver);
        }
    }*/

    public IEnumerator DeathBGM()
    {
        _audioSource.Stop();
        yield return new WaitForSeconds(delay);
        _audioSource.PlayOneShot(_gameOver);
    }
}
