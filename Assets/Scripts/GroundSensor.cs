using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3)
        {
            isGrounded = true;
        }
        else if(collider.gameObject.layer == 6)
        {
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
