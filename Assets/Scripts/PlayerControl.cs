using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float playerSpeed = 4.5f;
    public int playerDirection = 1;
    // Start is called before the first frame update
    void Start()
    {
        //Teletransporta al personaje
        //transform.position = new Vector3 (0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        //Mover automáticamente en X --> playerSpeed = velocidad    playerDirection = dirección en la que se mueve
        //transform.position = new Vector3 (transform.position.x + playerDirection * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        
        //Otra manera de mover el objeto con transform
        //transform.Translate(new Vector3 (playerDirection * playerSpeed * Time.deltaTime, 0, 0));
        
        //Move towards hace que el objeto vaya de un punto a otro
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), playerSpeed * Time.deltaTime);
    }
}
