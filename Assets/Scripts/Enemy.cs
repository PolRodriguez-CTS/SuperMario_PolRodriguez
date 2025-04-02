using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;
    public AudioClip _deathSFX;
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    public int direction = 1;
    public float speed = 2.5f;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        speed = 0;
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(direction * speed, _rigidBody.velocity.y);
    }

    public void Death()
    {
        
        direction = 0;
        _rigidBody.gravityScale = 0;
        _animator.SetTrigger("isDead");
        _audioSource.clip = _deathSFX;
        _audioSource.Play();
        _boxCollider.enabled = false;
        Destroy(gameObject, 0.3f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Tuberia") || collision.gameObject.layer == 6)
        {
            direction *= -1;
        }
       
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerControl playerScript = collision.gameObject.GetComponent<PlayerControl>();
            playerScript.Death();
            //Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            direction *= -1;
        }
    }

    void OnBecameVisible()
    {
        speed = 2.5f;
    }

    void OnbecameInvisible()
    {
        speed = 0;
    }
}
