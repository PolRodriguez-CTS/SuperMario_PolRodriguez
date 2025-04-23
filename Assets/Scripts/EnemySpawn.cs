using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //_ antes del nombre de la variable para diferenciar que son privadas
    //Serialuze field sirve para mostrar en el inspector la variable que queremos aunque sea privada
    //Header sirve para modificar cosas que salen en el inspector (títulos, etc)
    [Header("Spawn Enemigos")]
    [Tooltip("Prefabs de enemigos")]
    [SerializeField] private GameObject[] _enemiesPrefab;

    [Tooltip("Numero de enemigos que spawnear")]
    [SerializeField] private int _enemiesToSpawn;
    [SerializeField] private Transform[] _spawnPoint;
    private BoxCollider2D _collider;
    
    private int _enemyIndex;


    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        /*if(_enemiesToSpawn == 0)
        {
            CancelInvoke();
        }*/  
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            //desactivamos el collider para no llamar a esto varias veces
            _collider.enabled = false;
            //Invoke llama a la función que indiquemos, esperando un delay que designemos
            //Invoke("SpawnEnemy", 5);
            //También está InvokeRepeating, hace lo mismo pero repetidamente: InvokeRepeating("Nombre función", delay de entrada, delay de repetición);
            StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies()
    {
        for(int i = 0; i < _enemiesToSpawn; i++)
        {
            //Si lo usamos con ints --> (minimo incluido, maximo sin incluir) (0, 6) (entre 0 y 5)
            //Con floats es mínimo y máximo incluido
            foreach(Transform spawn in _spawnPoint)
            {
                _enemyIndex = Random.Range(0, _enemiesPrefab.Length);
                Instantiate(_enemiesPrefab[_enemyIndex], spawn.position, spawn.rotation);
                yield return new WaitForSeconds(1);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
