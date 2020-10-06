using UnityEngine;
using Mirror;
using System.Collections.Generic;

/*
	Documentation: https://mirror-networking.com/docs/Guides/NetworkBehaviour.html
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkBehaviour.html
*/

public class MoveGear : NetworkBehaviour
{
    Gyroscope gyro;
    public Quaternion speed;
    public Quaternion correctionQuaternion;

    [Command]
    public void sendSpeed(Quaternion newSpeed)
    {
        this.speed = newSpeed;
    }

    void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
        correctionQuaternion = Quaternion.Euler(90f, 0f, 0f);
    }

    void Update()
    {
        //speed = 0;
        print(gyro.attitude);
        Quaternion calculatedRotation = correctionQuaternion * GyroToUnity(gyro.attitude);
        transform.rotation = calculatedRotation;
        speed = calculatedRotation * new Quaternion(0,0,1,0);
        sendSpeed(speed);
    }
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
