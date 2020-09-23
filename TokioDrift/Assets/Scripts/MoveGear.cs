using UnityEngine;
using Mirror;
using System.Collections.Generic;
using UnityEngine.UI;

/*
	Documentation: https://mirror-networking.com/docs/Guides/NetworkBehaviour.html
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkBehaviour.html
*/

public class MoveGear : NetworkBehaviour
{
    public float speed;
    Text speedText;

    [Command]
    public void sendSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }

    void Start()
    {
        speedText = GameObject.Find("CartSpeed").GetComponent<Text>();
    }

    void Update()
    {
        if (speed >= 0.5f)
            speed = 3;
        else if (speed >= 0.3f && speed < 0.5f)
            speed = 2;
        else if (speed >= 0.1f && speed < 0.3f)
            speed = 1;
        else if (speed < -0.4f)
            speed = -2;
        else if (speed < -0.2f)
            speed = -1;
        else
            speed = 0;

        speedText.text = speed.ToString();
    }
}
