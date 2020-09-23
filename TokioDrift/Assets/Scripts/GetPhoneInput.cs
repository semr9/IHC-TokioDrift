using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//using UnityEngine;
using UnityEngine.UI;


public class GetPhoneInput : MonoBehaviour
{
    GameObject GearBox;
    GameObject networkManager;
    NetworkManager manager;
    float speed;
    public Text speedText;

    public void WriteString()
    {
        //speedText.text = speed.ToString();
    }

    public void ReadString()
    {
        print("Speed: " + speedText.text);
    }

    public float getSpeed()
    {
        return speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;

        networkManager = GameObject.Find("NetworkManager");
        if (networkManager == null)
            print("networkManager not found");
        manager = networkManager.GetComponent<NetworkManagerCar>();
        if (manager == null)
            print("manager not found");
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.numPlayers == 0) return;
            GearBox = GameObject.Find("Sphere(Clone)");
        if (GearBox == null)
            print("gearBox load failed");
        else
        {
            print("Success");
            //speed = GearBox.GetComponent<MoveGear>().getSpeed();
            print("Speed: " + speed.ToString());
            print(speed);
            WriteString();
            ReadString();
        }

            //print("Gear box loaded");
    }
}
