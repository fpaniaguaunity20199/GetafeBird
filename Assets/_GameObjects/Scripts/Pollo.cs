using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pollo : MonoBehaviour
{
    //********************************************
    //ZONA DE DECLARACION
    //********************************************
    Rigidbody rb;//Declaración
    AudioSource audioSource;//Audio source el audioSource
    public int puntuacion = 0;
    public Text txtPuntuacion;
    public int fuerza = 550;
    [SerializeField] GameObject prefabSangre;//Sistema de particulas de la explosion
    [SerializeField] AudioClip sonidoAlas;
    [SerializeField] AudioClip sonidoPuntuacion;
    [SerializeField] GameObject botonReload;

    void Start()
    {
        rb = GetComponent<Rigidbody>();//Inicialización
        audioSource = GetComponent<AudioSource>();
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
        audioSource.PlayOneShot(sonidoAlas);
        rb.AddForce(Vector3.up * fuerza);//0,1,0
    }

    private void OnCollisionEnter(Collision collision)
    {
        Morir();
    }

    private void Morir()
    {
        botonReload.SetActive(true);
        Instantiate(prefabSangre, transform.position, transform.rotation);
        GameManager.playing = false;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Limite") == true)
        {
            Morir();
        } else
        {
            audioSource.PlayOneShot(sonidoPuntuacion);
            puntuacion++;
            txtPuntuacion.text = puntuacion.ToString();
        }
        
    }
}
