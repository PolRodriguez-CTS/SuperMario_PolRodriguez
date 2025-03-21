using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisteryBox : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;
    public AudioClip _misteryBoxSFX;
    public AudioClip _misteryBoxOpenSFX;
    private bool _isOpen = false;

    void Awake ()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void ActivateBox()
    {
        if(!_isOpen)
        {
            _animator.SetTrigger("OpenBox");
            /*
            Modificar el volumen del audio
            _audioSource.volume = num entre 0 - 100
            */
            _audioSource.clip = _misteryBoxSFX;
            _isOpen = true;
        }
        else
        {
            _audioSource.clip = _misteryBoxOpenSFX;
        }
        _audioSource.Play();
        /*
        Otras funciones de AudioSource
        .Play --> Reproduce
        .Pause --> Pausa, se puede reanudar desde donde se pausó el sonido
        .Stop --> Se para el sonido y si se vuelve a reproducir empieza desde el principio
        */
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player")) 
        {
            ActivateBox();
        }
    }
}