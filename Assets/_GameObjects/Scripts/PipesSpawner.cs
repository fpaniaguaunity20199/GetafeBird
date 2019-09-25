using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{
    public GameObject prefabPipe;
    public float ratio;
    void Start()
    {
        InvokeRepeating("SpawnPipe", 0, ratio);//Cada 'ratio' segundos, empezando de inmediato
    }
    void SpawnPipe()
    {
        if (GameManager.playing == true)
        {
            Instantiate(prefabPipe, transform);
        }
    }
}
