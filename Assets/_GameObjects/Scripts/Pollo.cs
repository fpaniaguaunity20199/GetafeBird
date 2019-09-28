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
    public Text txtBest;
    public int fuerza = 550;
    [SerializeField] GameObject prefabSangre;//Sistema de particulas de la explosion
    [SerializeField] AudioClip sonidoAlas;
    [SerializeField] AudioClip sonidoPuntuacion;
    [SerializeField] GameObject botonReload;
    private float delay = 0.1f;//Tiempo mínimo entre saltos
    private float deltaUltimoSalto = 0;//Tiempo transcurrido desde el último salto
    private static string BEST_KEY = "Best";
    void Start()
    {
        rb = GetComponent<Rigidbody>();//Inicialización
        audioSource = GetComponent<AudioSource>();
        txtBest.text = "Best:" + PlayerPrefs.GetInt(BEST_KEY, 0).ToString();
    }

    void Update()
    {
        deltaUltimoSalto += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) || PulsacionPantalla())
        {
            //Solo salta si ha transcurrido un tiempo mayor que delay desde el último salto y está bajando
            if (rb.velocity.y <= 0 && deltaUltimoSalto >= delay)
            {
                Saltar();
            }
        }
    }

    bool PulsacionPantalla()
    {
        bool pulsacion = false;
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                pulsacion = true;
            }
        }
        return pulsacion;
    }

    void Saltar()
    {
        deltaUltimoSalto = 0;
        audioSource.PlayOneShot(sonidoAlas);
        rb.AddForce(Vector3.up * fuerza);//0,1,0
    }

    private void OnCollisionEnter(Collision collision)
    {
        Morir();
    }

    private void Morir()
    {
        int max = puntuacion;
        if (PlayerPrefs.HasKey(BEST_KEY))
        {
            max = Mathf.Max(PlayerPrefs.GetInt(BEST_KEY), puntuacion);
        }
        PlayerPrefs.SetInt(BEST_KEY, max);
        PlayerPrefs.Save();

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
