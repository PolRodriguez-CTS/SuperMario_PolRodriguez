using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimerScript : MonoBehaviour
{
    //enteros
    public int numeroEntero = 0;

    //variable de texto
    //string cadenaTexto = "Hola Mundo";

    // Start is called before the first frame update
    void Start()
    {
       Calculos();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void Calculos()
    {
         Debug.Log(numeroEntero);
        numeroEntero = 17;
        Debug.Log(numeroEntero);

        numeroEntero = 7+ 5;

        numeroEntero++;

        numeroEntero +=2;

    }
}
