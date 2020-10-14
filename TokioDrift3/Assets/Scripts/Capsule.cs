using UnityEngine;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class Capsule : MonoBehaviour
{
    Thread receiveThread;
    UdpClient client;
    int port;

    public GameObject Player;
    bool straight;
    bool left;
    bool right;

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 40, 215, 9999));
            GUILayout.Label("Port: " + port);

        GUILayout.EndArea();

    }

    void Start()
    {
        port = 5065;
        straight = left = right = false;
        InitUDP();
    }

    private void InitUDP()
    {
        //logger.Log("UDP Initialized");
        print("UDP Initialized");
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    private void ReceiveData()
    {
        try
        {
            client = new UdpClient(port);
            while (true)
            {
                try
                {
                    IPEndPoint anyIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
                    byte[] data = client.Receive(ref anyIP);

                    string text = Encoding.UTF8.GetString(data);
                    print(">> " + text);

                    if (String.Equals(text, "straight"))
                    {
                        straight = true;
                        left = right = false;
                    }
                    else if (String.Equals(text, "left"))
                    {
                        left = true;
                        straight = right = false;
                    }
                    else if (String.Equals(text, "right"))
                    {
                        right = true;
                        left = straight = false;
                    }
                }
                catch (Exception e)
                {
                    print(e.ToString());
                }
            }
        } catch(Exception e)
        {
            print("Already a connection"); 
        }
    }


    void Update()
    {
        if (straight == true)
        {
            Player.transform.Translate(0, 0, 0);
            //Fstraight();
            straight = false;
        }
        else if (right == true)
        {
            Player.transform.Translate(0.1f, 0, 0);
            //Fright();
            right = false;
        }
        else if (left == true)
        {
            Player.transform.Translate(-0.1f, 0, 0);
            //Fleft();
            left = false;
        }
    }
}
