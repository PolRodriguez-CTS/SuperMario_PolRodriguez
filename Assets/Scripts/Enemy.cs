using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;
    public AudioClip _deathSFX;
    public AudioClip _damageSFX;
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    public int direction = 1;
    public float speed = 2.5f;
    public float maxHealth = 5;
    private float currentHealth;
    private Slider _healthBar;
    private GameManager _gameManager;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _healthBar = GetComponentInChildren<Slider>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        _healthBar.maxValue = maxHealth;
        _healthBar.value = maxHealth;
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(direction * speed, _rigidBody.velocity.y);
    }

    public void Death()
    {
        _gameManager.AddGoombas();
        direction = 0;
        _rigidBody.gravityScale = 0;
        _animator.SetTrigger("isDead");
        _audioSource.clip = _deathSFX;
        _audioSource.Play();
        _boxCollider.enabled = false;
        Destroy(gameObject, 0.3f);
    }

    public void TakeDamage(float damage)
    {
        _audioSource.PlayOneShot(_damageSFX);
        currentHealth-= damage;
        _healthBar.value = currentHealth;
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Tuberia") || collision.gameObject.layer == 6 || collision.gameObject.CompareTag("Pared"))
        {
            direction *= -1;
        }
       
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerControl playerScript = collision.gameObject.GetComponent<PlayerControl>();
            playerScript.Death();
            //Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Wall"))
        {
            direction *= -1;
        }
    }

    void OnbecameVisible()
    {
        direction = 1;
    }

    void OnbecameInvisible()
    {
        direction = 0;
    }
}
