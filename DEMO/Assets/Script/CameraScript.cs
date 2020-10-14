using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject quad;

    void Start()
    {
        float orthoSize = Screen.height / Screen.width * 0.5f;
        //Camera.main.orthographicSize = orthoSize;
        print("Height: " + Screen.height.ToString());
        print("Width: " + Screen.width.ToString());
    }

}
