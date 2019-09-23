using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sangre : MonoBehaviour
{
    private void OnDestroy()
    {
        GameManager.Reload();
    }
}
