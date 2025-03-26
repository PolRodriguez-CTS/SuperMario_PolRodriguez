using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    private GameManager _gameManager;
    public AudioClip _bgm;
    public AudioClip _gameOver;
    public float delay = 3;
    public float timer;
    //Varaible comprobar contador ha terminado --> private bool timerFinsished = false;
    
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
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
