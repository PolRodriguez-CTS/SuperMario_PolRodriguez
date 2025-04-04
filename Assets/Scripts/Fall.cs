using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    private BoxCollider2D _boxCollider;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerControl _playerScript = collision.gameObject.GetComponent<PlayerControl>();
            _playerScript.Death();
        }
    }
}
