using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ImageSteeringWheel;
    public GameObject Car;

    public GameObject Text1IndicarR;
    public GameObject Text1IndicarL;
    public GameObject Text1IndicarS;

    public GameObject ImageRight;
    public GameObject ImageWrong;

    public GameObject TextFinal;
    public GameObject ButtonNextTutorial;

    private bool stateChange;
    private int state;
    private int cont;
    private long size;

    void Start()
    {
        stateChange = false;
        state = 0;
        cont = 0;
        size = 50000000;
    }

    // Update is called once per frame
    void Update()
    {
        if (stateChange)
        {
            ImageWrong.SetActive(false);
            ImageRight.SetActive(true);
            while (cont < size) { cont++; }
            cont = 0;
            Text1IndicarR.SetActive(false);
            Text1IndicarS.SetActive(false);
            Text1IndicarL.SetActive(false);
            state++;
            stateChange = false;
            ImageRight.SetActive(false);
            ImageWrong.SetActive(false);
        }
        ImageSteeringWheel.transform.eulerAngles = new Vector3(0, 0, -1 * Car.transform.eulerAngles.y);
        if (state == 0)
        {//voltear a la derecha
            Text1IndicarR.SetActive(true);
            if (Car.transform.eulerAngles.y > 70 && Car.transform.eulerAngles.y < 90)
            {
                stateChange = true;
                ImageWrong.SetActive(false);
                ImageRight.SetActive(true);
            }
            else
            {
                ImageRight.SetActive(false);
                ImageWrong.SetActive(true);
            }
        }
        else if (state == 1)
        {
            Text1IndicarL.SetActive(true);
            if (Car.transform.eulerAngles.y > 270 && Car.transform.eulerAngles.y < 290)
            {
                stateChange = true;
                ImageWrong.SetActive(false);
                ImageRight.SetActive(true);
            }
            else
            {
                ImageRight.SetActive(false);
                ImageWrong.SetActive(true);
            }

        }
        else if (state == 2)
        {
            Text1IndicarS.SetActive(true);
            if ((Car.transform.eulerAngles.y > 350 && Car.transform.eulerAngles.y <= 360) || (Car.transform.eulerAngles.y >= 0 && Car.transform.eulerAngles.y < 10))
            {
                stateChange = true;
                ImageWrong.SetActive(false);
                ImageRight.SetActive(true);
            }
            else
            {
                ImageRight.SetActive(false);
                ImageWrong.SetActive(true);
            }

        }
        else if (state == 3)
        {
            ImageRight.SetActive(true);
            TextFinal.SetActive(true);
            ButtonNextTutorial.SetActive(true);
        }
    }
}
