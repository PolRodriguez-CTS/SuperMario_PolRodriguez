using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;
    public AudioClip _coinSFX;
    private GameManager _gameManager;
    

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            CoinDeath();
        }
    }

    void CoinDeath()
    {   
        _gameManager.AddCoins();
        _boxCollider.enabled = false;
        _audioSource.PlayOneShot(_coinSFX);
        _spriteRenderer.enabled = false;
        Destroy (gameObject, _coinSFX.length);
    }
}
