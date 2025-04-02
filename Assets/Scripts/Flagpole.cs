using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
   private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;
    public AudioClip _flagPoleSFX;
    public bool hasWinned = false;
   

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
            Victory();
        }
    }

    void Victory()
    {   
        _boxCollider.enabled = false;
        _audioSource.PlayOneShot(_flagPoleSFX);
        hasWinned = true;
    }
}
