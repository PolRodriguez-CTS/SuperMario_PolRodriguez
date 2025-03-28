using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public float bulletForce = 10;

    
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rigidBody.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6)
        {
            //creamos variable para almacenar el script de enemy y así poder llamar a la función de muerte del goomba
            Enemy _enemyScript = collider.gameObject.GetComponent<Enemy>();
            _enemyScript.Death();
            BulletDeath();
        }
        if(collider.gameObject.layer == 3)
        {
            BulletDeath();
        }
    }

    void BulletDeath()
    {
        Destroy(gameObject);
    }
}