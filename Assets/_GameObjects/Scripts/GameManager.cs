using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool playing = false;
    public static void Reload()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }    
}
