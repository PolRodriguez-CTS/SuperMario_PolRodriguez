using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Variable donde leeremos las coordenadas del jugador
    public Transform playerTransform;
    //variable tipo vector con tres componentes (x,y,z) para hacer un offset a la cámara
    public Vector3 offset;
    //Posición máxmima y mínima que podrán tener los valores X, Y del transform de la cámara
    public Vector2 maxPosition;
    public Vector2 minPosition;

    public float interpolationRatio = 0.5f;

    void Awake()
    {
        //Busca un objeto por el nombre en la escena
        //playerTransform = GameObject.Find("Mario_0").transform;

        //Busca un objeto por el tag
        playerTransform = GameObject.FindWithTag ("Player").transform;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Queremos que la posición de la cámara sea igual a la del jugador (Mario) + el offset
        Vector3 desiredPosition = playerTransform.position + offset;

        //Creamos los límites de la posición en X e Y de la cámara
        float clampX = Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x);
        float ClampY = Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y);
        Vector3 clampedPosition = new Vector3(clampX, ClampY, desiredPosition.z);

        Vector3 lerpedPosition = Vector3.Lerp(transform.position, clampedPosition, interpolationRatio);
        //Hacemos que la posición ahora equivalga a clamped position, Clammped position = posición del jugador + el offset + los límites
        transform.position = lerpedPosition;
    }
}
