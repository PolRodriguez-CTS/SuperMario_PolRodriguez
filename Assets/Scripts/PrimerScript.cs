using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimerScript : MonoBehaviour
{
    //Arrays: colección de datos de tamaño fijo. Pueden ser de cualquier tipo de variables, pero el array solo puede tener un tipo distinto de variable (todo int, todo float, etc)
    /*Bucles*/

    private int[] numeros = {69, 41, 33};

    //Los arrays también se pueden ver desde el inspector de Unity (solo los de una dimensión)
    public int[] numeros2;
    
    //Array de más de una dimensión
    private int[,] numeros3 = {{7, 8, 98}, {9, 22, 45}, {3, 4, 5}};

    //List<Tipo de valor de la lista>
    List<int> listaDeNumeros = new List<int> {3, 5, 8, 9, 10, 6};

    void Start()
    {
        //Debug.Log(numeros[0]);
        //Debug.Log(numeros3[1, 2]);
        //Este bucle se utiliza en colecciones o arrays, se repite por cada elemento que exista en la colección
        /*foreach(int numero in numeros)
        {
            Debug.Log(numero);
        }*/

        //Se ejecuta mientras la variable de control cumpla la condición, cada vez que ejecuta, el último parámetro le hace algo a la variable de control.
        /*for(int i = 0; i < numeros.Length; i++)
        {
            Debug.Log(numeros[i]);
        }*/

        //Se ejecuta mientras la condición sea verdadera
        /*int i = 0;
        while(i < numeros.Length)
        {
            Debug,Log(numeros[i]);
            i++;
        }*/

        //la diferencia entre do while y while es que while puede que no se ejecute nunca ya que puede no cumplirse la condición, 
        //y do while ejecuta al menos una vez aunque no se cumpla la condición
        /*do
        {

        }
        while ();
        */
        //For each en una lista
        /*foreach(int numero in listaDeNumeros)
        {
            Debug.Log(numero)
        }*/

        //añadir números, eliminar número (número en concreto), eliminar una posición concreta --> remove at (posición en la lista), clear vacía la lista
        //listaDeNumeros.Add(22);
        //listaDeNumeros.Remove(5);
        //listaDeNumeros.RemoveAt(0);
        //listaDeNumeros.RemoveAt(listaDeNumeros.Count - 1);
        //listaDeNumeros.Clear();

        //Ordenar la lista por su valor, revertir los valores
        //listaDeNumeros.Sort();
        //listaDeNumeros.Reverse();
    }


}
