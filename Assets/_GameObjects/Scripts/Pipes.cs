using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public int speed;
    public float rango;
    private void Start()
    {
        //transform.Translate(0, Random.Range(rango*-1,rango), 0);
        //transform.Translate(new Vector3(0, Random.Range(rango * -1, rango), 0));
        //transform.Translate(Vector3.up * Random.Range(rango * -1, rango));
        Vector3 altura = new Vector3(0, Random.Range(rango * -1, rango), 0);
        transform.Translate(altura);
    }


    void Update()
    {
        if (GameManager.playing == true) {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.name == "Limit")
        {
            Destroy(gameObject);
        }
    }
}
