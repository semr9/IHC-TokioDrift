using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWheel : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ImageSteeringWheel;
    public GameObject Car;

    public GameObject Text1IndicarRight;
    public GameObject Text1IndicarWrong;

    public GameObject ImageRight;
    public GameObject ImageWrong;

    private bool stateChange;

    void Start()
    {
        stateChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        //ImageSteeringWheel.transform.eulerAngles = new Vector3(0, 0, -1 * Car.transform.eulerAngles.y);
        //if (!stateChange)
        //{
        //    Text1IndicarWrong.SetActive(true);
        //    Text1IndicarRight.SetActive(false);

        //    ImageWrong.SetActive(true);
        //    ImageRight.SetActive(false);

        //    if (Car.GetComponent<KartGame.KartSystems.KeyboardInput>().StateDetect) stateChange = true; // if cnot detecting change
        //}
        //else
        //{
        //    Text1IndicarWrong.SetActive(false);
        //    Text1IndicarRight.SetActive(true);

        //    ImageWrong.SetActive(false);
        //    ImageRight.SetActive(true);

        //    if (!Car.GetComponent<KartGame.KartSystems.KeyboardInput>().StateDetect) stateChange = false;
        //}
    }
}

