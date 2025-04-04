using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    public float speed = 2;
    private int direction = 1;
    private AudioSource _audioSource;
    public AudioClip _powerUpSFX;
    private SpriteRenderer _spriteRenderer;
    
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
            PlayerControl playerScript = collision.gameObject.GetComponent<PlayerControl>();
            playerScript.canShoot = true;
            playerScript.shootTimer = 0;
            EatMushroom();
        }
    }

    void EatMushroom()
    {
        direction = 0;
        _rigidBody.gravityScale = 0;
        _boxCollider.enabled = false;
        _spriteRenderer.enabled = false;
        _audioSource.PlayOneShot(_powerUpSFX);
        Destroy (gameObject, _powerUpSFX.length);
    }
}
