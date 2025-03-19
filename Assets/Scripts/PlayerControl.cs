using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float playerSpeed = 4.5f;
    public int playerDirection = 1;
    //almacena si pulsamos el boton para movernos
    private float inputHorizontal;
    //variable de componente
    private Rigidbody2D rigidBody;
    public float jumpForce = 15;
    public GroundSensor _groundSensor;

    public SpriteRenderer _spriteRenderer;
    
    //función de Unity que se llama sola
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _groundSensor = GetComponentInChildren<GroundSensor>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //Teletransporta al personaje
        //transform.position = new Vector3 (0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        //este input lo podemos encontrar en Unity como bindeo de tecla de los controles del jugador.
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        //Mover automáticamente en X --> playerSpeed = velocidad    playerDirection = dirección en la que se mueve
        //transform.position = new Vector3 (transform.position.x + playerDirection * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        
        //Otra manera de mover el objeto con transform
        //transform.Translate(new Vector3 (playerDirection * playerSpeed * Time.deltaTime, 0, 0));
        
        //Move towards hace que el objeto vaya de un punto a otro
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + inputHorizontal, transform.position.y), playerSpeed * Time.deltaTime);
        //condición para el salto
        if(Input.GetButtonDown("Jump") && _groundSensor.isGrounded == true)
        {
            Jump();
        }
        Movement();
    }

    void FixedUpdate()
    {
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
            _spriteRenderer.flipX = false;
        }
        else if(inputHorizontal < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    void Jump()
    {
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}