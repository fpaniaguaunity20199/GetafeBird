using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollo : MonoBehaviour
{
    Rigidbody rb;//Declaración
    private int fuerza = 750;
    void Start()
    {
        print("En el Start");
        rb = GetComponent<Rigidbody>();//Inicialización
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
    }

    void Saltar()
    {
        rb.AddForce(Vector3.up * fuerza);//0,1,0
    }
}
