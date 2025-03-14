using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float playerSpeed = 4.5f;
    public int playerDirection = 1;
    private float inputHorizontal;
    private Rigidbody2D rigidBody;
    public float jumpForce = 10;
    public GroundSensor _groundSensor;
    
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _groundSensor = GetComponentInChildren<GroundSensor>();
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
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        //Mover automáticamente en X --> playerSpeed = velocidad    playerDirection = dirección en la que se mueve
        //transform.position = new Vector3 (transform.position.x + playerDirection * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        
        //Otra manera de mover el objeto con transform
        //transform.Translate(new Vector3 (playerDirection * playerSpeed * Time.deltaTime, 0, 0));
        
        //Move towards hace que el objeto vaya de un punto a otro
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + inputHorizontal, transform.position.y), playerSpeed * Time.deltaTime);
        //condición para el salto
        if(Input.GetButtonDown("Jump") && !_groundSensor.isGrounded == false)
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        //Tres maneras de mover el personaje con rigidbody
        rigidBody.velocity = new Vector2(inputHorizontal*playerSpeed, rigidBody.velocity.y);
        //rigidBody.AddForce(new Vector2(inputHorizontal,0));
        //rigidBody.MovePosition(new Vector2(100,0));
    }
}
