using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public SpriteRenderer _spriteRenderer;

    public BoxCollider2D _collider1;

    public BoxCollider2D _collider2;

    private AudioSource _audioSource;

    public AudioClip _boxSFX;

    void Awake ()
    {
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void DestroyBox()
    {
        _audioSource.clip = _boxSFX;
        _audioSource.Play();

        _spriteRenderer.enabled = false;
        _collider1.enabled = false;
        _collider2.enabled = false;
        Destroy(gameObject, _boxSFX.length);
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
         //También se puede usar collider.gameObject.CompareTag("Player") o collider.gameObject.tag == "Player"
        if(collider.gameObject.CompareTag("Player")) 
        {
            DestroyBox();
        }
    }
}
