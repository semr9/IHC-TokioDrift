using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControllerTutorial2 : MonoBehaviour
{

    public Quaternion speed;

    // state (0, 1 or 2)
    private int state;
    public bool started;
    private float timer;
    public bool phoneConnected;
    private float sameAngleCount;

    // timer text
    public TextMeshProUGUI angle;
    public TextMeshProUGUI maxAngle;
    public TextMeshProUGUI minAngle;
    public TextMeshProUGUI textTimer;

    // general info
    public TextMeshProUGUI Title;
    public TextMeshProUGUI TextMobileConn;

    public GameObject StartButton;
    public GameObject NextTutorial;

    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        started = false;
        sameAngleCount = 0;
        phoneConnected = false;

    }

    void State0(float res)
    {
        if (res < 0.1)
        {
            if (timer > 3)
            {
                timer = 0;
                sameAngleCount = 3;
                maxAngle.text = speed.x.ToString("0.0");
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
            if (timer > 3)
            {
                timer = 0;
                sameAngleCount = 3;
                minAngle.text = speed.x.ToString("0.0");
            }
        }
        else
        {
            timer = 0;
            sameAngleCount = 0;
        }
    }

    void ActivateStartButton()
    {
        StartButton.SetActive(true);
    }

    void showTutorialButton()
    {
        NextTutorial.SetActive(true);
        started = false;
    }

    public void toggleStart()
    {
        TextMobileConn.text = "Step 1/2";
        Title.text = "Acceleration: Move the phone up as much as you can for 3 seconds!";
        //Title.text = "Mueve el celular hacia arriba para determinar la aceleracion maxima de tu pedal";
        started = true;

        StartButton.SetActive(false);
        //RectTransform tmp = GameObject.Find("StartButton").GetComponent<RectTransform>();
        //tmp.anchoredPosition = new Vector2(362, tmp.anchoredPosition.y);
    }

    void changeTitles1()
    {
        TextMobileConn.text = "Step 2/2";
        Title.text = "Deacceleration: Move the phone down as much as you can  for 3 seconds!";
    }

    void changeTitles2()
    {
        TextMobileConn.text = "Good Job!";
        Title.text = "Good job, now go to the next tutorial";
    }

    // Update is called once per frame
    void Update()
    {
        if (started == false) return;

        float res = Mathf.Abs(float.Parse(angle.text) - speed.x);
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
        angle.text = speed.x.ToString("0.0");
    }
}
