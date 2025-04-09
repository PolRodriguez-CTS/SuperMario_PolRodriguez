using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    private BoxCollider2D _boxCollider;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            PlayerControl _playerScript = collider.gameObject.GetComponent<PlayerControl>();
            _playerScript.Death();
        }
    }
}
