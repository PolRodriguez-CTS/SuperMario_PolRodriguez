using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;

    public float speed = 2;

    public int direction = 1;

    private AudioSource _audioSource;

    public AudioClip _powerUp;
    
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(direction * speed, _rigidBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Tuberia") || collision.gameObject.layer == 7)
        {
            direction *= -1;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Death();
        }
    }

    void Death()
    {
        direction = 0;
        _rigidBody.gravityScale = 0;
        _boxCollider.enabled = false;
        Destroy (gameObject);
        _audioSource.clip = _powerUp;
        _audioSource.Play();
    }
}
