using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;
    public AudioClip _coinSFX;
    

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            CoinDeath();
        }
    }

    void CoinDeath()
    {   
        _boxCollider.enabled = false;
        _audioSource.PlayOneShot(_coinSFX);
        _spriteRenderer.enabled = false;
        Destroy (gameObject, _coinSFX.length);
    }
}
