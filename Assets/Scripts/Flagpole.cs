using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flagpole : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;
    public AudioClip _flagPoleSFX;
    public bool hasWinned = false;
   
    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Victory();
            SoundManager _victoryBGM = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
            //_victoryBGM.VictoryBGM();
            StartCoroutine(_victoryBGM.VictoriaBGM());
        }
    }

    void Victory()
    {   
        _boxCollider.enabled = false;
        _audioSource.PlayOneShot(_flagPoleSFX);
        //La booleana solo sirve si uso la función VictoryBGM, como ahora estoy usando corutina no hace falta
        //hasWinned = true;
    }
}
