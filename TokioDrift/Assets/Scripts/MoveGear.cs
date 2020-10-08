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

    public Quaternion speed;

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

    [Command]
    public void sendSpeed(Quaternion newSpeed)
    {
        this.speed = newSpeed;
    }

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;

        state = 0;
        started = false;
        sameAngleCount = 0;

        if (currentScene != "Tutorial2")
            speedText = GameObject.Find("CartSpeed").GetComponent<Text>(); 
        else
        {
            showStartButton();

            angle = GameObject.Find("PhoneAngle").GetComponent<TextMeshProUGUI>();
            maxAngle = GameObject.Find("MaxAngle").GetComponent<TextMeshProUGUI>();
            minAngle = GameObject.Find("MinAngle").GetComponent<TextMeshProUGUI>();
            textTimer = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();

            TextMobileConn = GameObject.Find("TextMobileConn").GetComponent<TextMeshProUGUI>();
            Title = GameObject.Find("Title").GetComponent<TextMeshProUGUI>();
        }
    }

    void State0(float res)
    {
        if (res < 0.1)
        {
            if (timer > 1)
            {
                sameAngleCount++;
                maxAngle.text = speed.y.ToString("0.0");
                timer = 0;
            }
        }
        else
        {
            timer = 0;
            sameAngleCount = 0;
        }
    }

    void State1(float res)
    {
        if (res < 0.1)
        {
            if (timer > 1)
            {
                sameAngleCount++;
                minAngle.text = speed.y.ToString("0.0");
                timer = 0;
            }
        }
        else
        {
            timer = 0;
            sameAngleCount = 0;
        }
    } 

    void showTutorialButton()
    {
        RectTransform tmp = GameObject.Find("NextTutorial").GetComponent<RectTransform>();
        tmp.anchoredPosition = new Vector2(160, tmp.anchoredPosition.y);
    }

    void showStartButton()
    {
        RectTransform tmp = GameObject.Find("StartButton").GetComponent<RectTransform>();
        tmp.anchoredPosition = new Vector2(0, tmp.anchoredPosition.y);
    }

    public void toggleStart()
    {
        GameObject.Find("TextMobileConn").GetComponent<TextMeshProUGUI>().text = "Step 1/2";
        GameObject.Find("Title").GetComponent<TextMeshProUGUI>().text = "Acceleration: Move the phone up as much as you can!";
        //Title.text = "Mueve el celular hacia arriba para determinar la aceleracion maxima de tu pedal";
        GameObject.Find("Sphere(Clone)").GetComponent<MoveGear>().started = true;
        RectTransform tmp = GameObject.Find("StartButton").GetComponent<RectTransform>();
        tmp.anchoredPosition = new Vector2(362, tmp.anchoredPosition.y);
    }

    void changeTitles1()
    {
        TextMobileConn.text = "Step 2/2";
        Title.text = "Deacceleration: Move the phone down as much as you can!";
    }

    void changeTitles2()
    {
        TextMobileConn.text = "Good Job!";
        Title.text = "Good job, now go to the next tutorial";
    }

    void UpdateTutorial()
    {
        if (started == false) return;

        float res = Mathf.Abs(float.Parse(angle.text) - speed.y);
        if (state == 0) // move up
            State0(res);
        else if (state == 1) // move down
            State1(res);
        else if (state == 2) // tutorial done
            showTutorialButton();

        if (sameAngleCount == 3)
        {
            state++;
            sameAngleCount = 0;
            if (state == 1) changeTitles1(); else changeTitles2();
            GameObject.Find("ShowPhone").GetComponent<TutorialMovePhone>().state += 1;
        }
        timer += 1 * Time.deltaTime;
        textTimer.text = timer.ToString("0.0");
        angle.text = speed.y.ToString("0.0");
    }

    void UpdateMain()
    {
        /// no speed = 0.5
        /// acceleration = 0.0
        /// deacceleration = 1.0
        float currentSpeed = 0;
        if (speed.y <= 0.2f)
            currentSpeed = 3;
        else if (speed.y <= 0.3f && speed.y > 0.2f)
            currentSpeed = 2;
        else if (speed.y <= 0.4f && speed.y > 0.3f)
            currentSpeed = 1;
        else if (speed.y >= 0.7f)
            currentSpeed = -2;
        else if (speed.y >= 0.6f && speed.y < 0.7f)
            currentSpeed = -1;
        else
            currentSpeed = 0;

        speedText.text = currentSpeed.ToString();
    }

    void Update()
    {
        if(currentScene == "Tutorial2")
            UpdateTutorial();
        else
            UpdateMain();
    }
}
