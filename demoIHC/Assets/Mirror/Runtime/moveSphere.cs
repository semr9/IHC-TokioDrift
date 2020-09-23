using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSphere : MonoBehaviour
{
    void Update()
    {

        Debug.Log(Input.acceleration.x + " " + Input.acceleration.y + " " + Input.acceleration.z);
        transform.Translate(Input.acceleration.x * Time.deltaTime, Input.acceleration.y * Time.deltaTime, 0);
    }
}
