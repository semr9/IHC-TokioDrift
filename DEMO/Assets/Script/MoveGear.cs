using UnityEngine;
using Mirror;
using System.Collections.Generic;

/*
	Documentation: https://mirror-networking.com/docs/Guides/NetworkBehaviour.html
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkBehaviour.html
*/

public class MoveGear : NetworkBehaviour
{
    public float speed;

    [Command]
    public void sendSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }


    void Update()
    {
        speed = 0;
        if (Input.acceleration.x > 0.3f)
        {
            print("Move right");
            transform.Translate(Input.acceleration.x * Time.deltaTime, 0, 0);
        }
        else if (Input.acceleration.x < -0.3f)
        {
            print("Move left");
            transform.Translate(Input.acceleration.x * Time.deltaTime, 0, 0);
        }
        if (Input.acceleration.y > 0.40f)
        {
            print("Move up");
            speed = Input.acceleration.y;
            transform.Translate(0, Input.acceleration.y * Time.deltaTime, 0);
        }
        else if (Input.acceleration.y < -0.40f)
        {
            print("Move down");
            speed = Input.acceleration.y / 2;
            transform.Translate(0, Input.acceleration.y * Time.deltaTime, 0);
        }
        speed = (Input.acceleration.y > 0) ? Input.acceleration.y : Input.acceleration.y / 2;
        sendSpeed(speed);
    }
}
