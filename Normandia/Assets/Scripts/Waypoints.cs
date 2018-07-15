using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

    public static Transform[] points;

    //Carga el número de waypoints de la escena al iniciar
    void Awake()
    {
        //Cuenta el número de hijos del objeto al que hace referencia este script y crea un array de ese tamaño.
        points = new Transform[transform.childCount];

        //Mete a esos hijos en el array points.
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
