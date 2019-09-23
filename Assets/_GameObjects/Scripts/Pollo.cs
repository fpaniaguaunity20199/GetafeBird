using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pollo : MonoBehaviour
{
    public int puntuacion = 0;
    Rigidbody rb;//Declaración
    public Text txtPuntuacion;
    [SerializeField] GameObject prefabSangre;//Sistema de particulas de la explosion
    public int fuerza = 550;
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

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(prefabSangre, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        puntuacion++;
        txtPuntuacion.text = puntuacion.ToString();
    }
}
