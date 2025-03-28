using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded;
    private Rigidbody2D _rigidBody;

    void Awake()
    {
        //para acceder al rigid body del mario
        _rigidBody = GetComponentInParent<Rigidbody2D>();
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3)
        {
            isGrounded = true;
        }
        else if(collider.gameObject.layer == 6)
        {
            _rigidBody.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
            /*Lo que hace collider.GameObject aquí es hacer que se destruya el objeto 
            que entra en el collider de Mario (serán los objetos de la capa 6)*/
            //Destroy(collider.gameObject);
            Enemy _enemyScript = collider.gameObject.GetComponent<Enemy>();
            _enemyScript.Death();
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3)
        {
            isGrounded = false;
        }
    }
}
