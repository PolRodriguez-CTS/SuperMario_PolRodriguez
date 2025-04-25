using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float playerSpeed = 4.5f;
    public int playerDirection = 1;
    //almacena si pulsamos el boton para movernos
    private float inputHorizontal;
    //variable de componente
    public float jumpForce = 15;
    private Rigidbody2D rigidBody;
    private BoxCollider2D _boxCollider;
    public GroundSensor _groundSensor;
    public SpriteRenderer _spriteRenderer;
    private Animator _animator;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    private AudioSource _audioSource;
    public AudioClip jumpSFX;
    public AudioClip deathSFX;
    public AudioClip shootSFX;
    private GameManager _gameManager;
    private SoundManager _soundManager;
    public bool canShoot = false;
    public float shootDuration = 10;
    public float shootTimer;
    public Image _powerUpImage;
    private MenuManager _menuManager;

    [SerializeField] private float _dashforce = 20;
    [SerializeField] private float _dashDuration = 0.5f;
    [SerializeField] private float _dashCoolDown = 1;

    private bool _canDash = true;
    private bool _isDashing = false;

    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _attackDamage = 10;
    [SerializeField] private float _attackRadius = 1;

    [SerializeField] private Transform _hitBoxPosition;
    [SerializeField] private float _baseChargedAttackDamage = 15;
    [SerializeField] private float _maxChargedAttackDamage = 40;
    private float _chargedAttackDamage;
    

    
    //función de Unity que se llama sola
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _groundSensor = GetComponentInChildren<GroundSensor>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _menuManager = GameObject.Find("Menu Manager").GetComponent<MenuManager>();
        _soundManager = GameObject.FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //Teletransporta al personaje
        //transform.position = new Vector3 (0, 0, 0);
        _chargedAttackDamage = _baseChargedAttackDamage;
    }

    // Update is called once per frame
    void Update()
    {
        //Condicion, si hemos muerto no se ejecuta el código que permite movernos
        if(!_gameManager.isPlaying)
        {
            return;
        }
        if(_gameManager.isPaused)
        {
            return;
        }

        //sirve para parar el código mientras hacemos dash y que por lo tanto todo lo que hay bajo esta linea no se ejecuta (para evitar saltar mientras hacemos dash)
        if(_isDashing)
        {
            return;
        }
        //este input lo podemos encontrar en Unity como bindeo de tecla de los controles del jugador.
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        //Mover automáticamente en X --> playerSpeed = velocidad    playerDirection = dirección en la que se mueve
        //transform.position = new Vector3 (transform.position.x + playerDirection * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        
        //Otra manera de mover el objeto con transform
        //transform.Translate(new Vector3 (playerDirection * playerSpeed * Time.deltaTime, 0, 0));
        
        //Move towards hace que el objeto vaya de un punto a otro
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + inputHorizontal, transform.position.y), playerSpeed * Time.deltaTime);
        //condición para el salto
        
        if (Input.GetButtonDown("Jump"))
        {
            if(_groundSensor.isGrounded || _groundSensor.canDoubleJump)
            {
                Jump();
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && _canDash)
        {
            StartCoroutine(Dash());
        }
        /*
        if(Input.GetButtonDown("Jump") && _groundSensor.isGrounded)
        {
            Jump();
        }
        */
        
        if(Input.GetButtonDown("Fire2"))
        {
            NormalAttack();
        }
        

        /*if(Input.GetButton("Fire2"))
        {
            AttackCharge();
        }

        if(Input.GetButtonUp("Fire2"))
        {
            ChargedAttack();
        }*/

        Movement();

        _animator.SetBool("IsJumping", !_groundSensor.isGrounded);

        /*
        if(_groundSensor.isGrounded)
        {
            _animator.SetBool("IsJumping", false);
        }
        */

        if(Input.GetButtonDown("Fire1") && canShoot)
        {
            Shoot();
        }

        if(canShoot)
        {
            //Llama la función que inicia el timer del powerUp
            PowerUp();
        }
       
    }

    void FixedUpdate()
    {
        if(_isDashing)
        {
            return;
        }
        //Tres maneras de mover el personaje con rigidbody
        rigidBody.velocity = new Vector2(inputHorizontal*playerSpeed, rigidBody.velocity.y);

        //rigidBody.AddForce(new Vector2(inputHorizontal,0));
        //rigidBody.MovePosition(new Vector2(100,0));
    }

        //Función personalizada para hacer que mario mire hacia un lado u otro dependiendo de hacia dónde se mueva
    void Movement()
    {
        //Si el input horizontal es positivo, en el componente SpriteRenderer, Flip X no se activa, si el input horizontal es negativo, se activa
         if(inputHorizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsRunning", true);
        }
        else if(inputHorizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }

    void Jump()
    {
        if(!_groundSensor.isGrounded)
        {
            _groundSensor.canDoubleJump = false;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
            //aquí se pondrían las animaciones del doble salto
        }
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _animator.SetBool("IsJumping", true);
        _audioSource.PlayOneShot(jumpSFX);
    }

    IEnumerator Dash()
    {
        float gravity = rigidBody.gravityScale;
        rigidBody.gravityScale = 0;
        //esto evita que el personaje se desplace hacia arriba
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);

        _isDashing = true;
        _canDash = false;
        rigidBody.AddForce(transform.right*_dashforce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(_dashDuration);
        rigidBody.gravityScale = gravity;
        _isDashing = false;
        yield return new WaitForSeconds(_dashCoolDown);
        _canDash = true;
    }

    void NormalAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_hitBoxPosition.position, _attackRadius, _enemyLayer);
        //Overlapcircle crea un radio donde detecta lo que hay
        foreach(Collider2D enemy in enemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.TakeDamage(_attackDamage);
        }
    }

    void AttackCharge()
    {
        if(_chargedAttackDamage < _maxChargedAttackDamage)
        {
            _chargedAttackDamage += Time.deltaTime;
            Debug.Log(_chargedAttackDamage);
        }
        else
        {
            _chargedAttackDamage = _maxChargedAttackDamage;
        }
    }

    void ChargedAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_hitBoxPosition.position, _attackRadius, _enemyLayer);
        foreach(Collider2D enemy in enemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.TakeDamage(_chargedAttackDamage);
        }

        _chargedAttackDamage = _baseChargedAttackDamage;
    }


    public void Death()
    {
        _animator.SetTrigger("IsDead");
        _audioSource.PlayOneShot(deathSFX);
        _boxCollider.enabled = false;

        Destroy(_groundSensor.gameObject);

        inputHorizontal = 0;
        rigidBody.velocity = Vector2.zero;

        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        //_soundManager.Invoke("DeathBGM", 10);

        //llamar coruntina de otro script
        StartCoroutine(_soundManager.DeathBGM());

        _gameManager.isPlaying = false;

        Destroy(gameObject, deathSFX.length);

        _menuManager.GameOver();
    }

    void Shoot()
    {
        _audioSource.PlayOneShot(shootSFX);
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }

    void PowerUp()
    {
        shootTimer += Time.deltaTime;
        _powerUpImage.fillAmount = Mathf.InverseLerp(shootDuration, 0, shootTimer);
        if(shootTimer >= shootDuration)
        {
            canShoot = false;
            shootTimer = 0;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_hitBoxPosition.position, _attackRadius);
    }
}