using UnityEngine;
using Mirror;
using System.Collections.Generic;

/*
	Documentation: https://mirror-networking.com/docs/Guides/NetworkBehaviour.html
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkBehaviour.html
*/

public class Sphere : NetworkBehaviour
{
    #region Start & Stop Callbacks

    void Update()
    {
        if (!isLocalPlayer)
            return;


        Debug.Log(Input.acceleration.x + " " + Input.acceleration.y + " " + Input.acceleration.z);
        transform.Translate(Input.acceleration.x * Time.deltaTime, Input.acceleration.y * Time.deltaTime, 0);
    }
    #endregion
}
