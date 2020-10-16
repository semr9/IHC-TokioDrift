using UnityEngine;
using System;
using Mirror;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/*
	Documentation: https://mirror-networking.com/docs/Guides/NetworkBehaviour.html
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkBehaviour.html
*/

public class MoveGear : NetworkBehaviour
{
    private string currentScene;
    private Text speedText;

    private Quaternion speed;
    public Quaternion plainSpeed;
    bool gyroAvaivable;


    public bool started;
    private float timer;
    private int state;
    private float sameAngleCount;

    private TextMeshProUGUI angle;
    private TextMeshProUGUI maxAngle;
    private TextMeshProUGUI minAngle;
    private TextMeshProUGUI textTimer;
    
    private TextMeshProUGUI TextMobileConn;
    private TextMeshProUGUI Title;

    private GameObject StartButton;


    [Command]
    public void sendSpeed(Quaternion newSpeed, Quaternion newPlainSpeed, bool gyroInfo)
    {
        this.speed = newSpeed;
        this.plainSpeed = newPlainSpeed;
        this.gyroAvaivable = gyroInfo;
    }

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene != "Tutorial2")
            speedText = GameObject.Find("CartSpeed").GetComponent<Text>();
    }

    void UpdateMain()
    {
        /// no speed = 0.0
        /// max acceleration = 0.5
        /// max deacceleration = -0.5
        float currentSpeed = 0;
        if(gyroAvaivable)
        {
            print("vel: " + plainSpeed.x.ToString("0.0"));
            if (plainSpeed.x >= 0.1)
            {
                if (plainSpeed.x >= 0.4f)
                    currentSpeed = 3;
                else if (plainSpeed.x >= 0.3f)
                    currentSpeed = 2;
                else if (plainSpeed.x >= 0.2f)
                    currentSpeed = 1;
            } else {
                if (plainSpeed.x <= -0.4f)
                    currentSpeed = -2;
                else if (plainSpeed.x <= -0.3f)
                    currentSpeed = -1;
                else if (plainSpeed.x <= -0.2f)
                    currentSpeed = -0.5f;
                else
                    currentSpeed = 0;
            }
        }
        speedText.text = currentSpeed.ToString();
    }

    void Update()
    {
        if (currentScene == "Tutorial2")
            GameObject.Find("TutorialController").GetComponent<ControllerTutorial2>().speed = this.plainSpeed;
        else
            UpdateMain();
    }

    void OnDestroy()
    {
        if(currentScene != "Tutorial2")
            speedText.text = "0";
    }

}
