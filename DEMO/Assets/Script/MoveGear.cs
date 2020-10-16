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
    public bool gyroAvaivable;
    public Quaternion speed;
    public Quaternion plainSpeed;
    public Quaternion correctionQuaternion;

    [Command]
    public void sendSpeed(Quaternion newSpeed, Quaternion newPlainSpeed, bool gyroInfo)
    {
        this.speed = newSpeed;
        this.plainSpeed = newPlainSpeed;
        this.gyroAvaivable = gyroInfo;
    }


    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            correctionQuaternion = Quaternion.Euler(90f, 0f, 0f);
            gyroAvaivable = true;
        } else
            gyroAvaivable = false;
    }

    void Update()
    {
        if(!gyroAvaivable)
        {
            sendSpeed(speed, plainSpeed, gyroAvaivable);
            return;
        }
        plainSpeed = GyroToUnity(gyro.attitude);

        Quaternion calculatedRotation = correctionQuaternion * GyroToUnity(gyro.attitude);
        transform.rotation = calculatedRotation;
        speed = calculatedRotation * new Quaternion(0,0,1,0);
        sendSpeed(speed, plainSpeed, true);
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
