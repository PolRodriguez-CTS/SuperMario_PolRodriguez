using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisteryBox : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;
    public AudioClip _MisteryBoxSFX;

    void Awake ()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void ActivateBox()
    {
        _animator.SetTrigger("OpenBox");
        _audioSource.clip = _MisteryBoxSFX;
        _audioSource.Play();
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player")) 
        {
            ActivateBox();
        }
    }
}