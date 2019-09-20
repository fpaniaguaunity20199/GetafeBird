using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public int speed;

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
