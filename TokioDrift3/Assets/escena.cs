using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escena : MonoBehaviour
{
    public void cambiarescena(string nombreescena)
    {
        SceneManager.LoadScene(1);
    }
}
