using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimerScript : MonoBehaviour
{
    //Arrays: colección de datos de tamaño fijo. Pueden ser de cualquier tipo de variables, pero el array solo puede tener un tipo distinto de variable (todo int, todo float, etc)

    private int[] numeros = {69, 41, 33};

    //Los arrays también se pueden ver desde el inspector de Unity (solo los de una dimensión)
    public int[] numeros2;
    
    //Array de más de una dimensión
    private int[,] numeros3 = {{7, 8, 98}, {9, 22, 45}, {3, 4, 5}};


    void Start()
    {
        Debug.Log(numeros[0]);
        Debug.Log(numeros3[1, 2]);
    }
}
