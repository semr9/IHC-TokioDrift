using UnityEngine;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class RotateOnAxisWheel : MonoBehaviour
{
	[Tooltip("Applies a rotation of eulerAngles.z degrees around the z-axis, eulerAngles.x degrees around the x-axis, and eulerAngles.y degrees around the y-axis (in that order).")]
	public Vector3 rotationSpeed;
	public bool rotate;
	Thread receiveThread; //1
	UdpClient client; //2
	int port; //3

	public int ejex;

	void Start()
	{
		port = 5065; //1 
		ejex = 0;
		InitUDP(); //4
	}

	private void InitUDP()
	{
		print("UDP Initialized");

		receiveThread = new Thread(new ThreadStart(ReceiveData)); //1 
		receiveThread.IsBackground = true; //2
		receiveThread.Start(); //3
	}


	private void ReceiveData()
	{
        try
        {
			client = new UdpClient(port); //1
		}
        catch (Exception e)
        {
			client = new UdpClient(50003);
        }
		while (true) //2
		{
			try
			{
				IPEndPoint anyIP = new IPEndPoint(IPAddress.Parse("0.0.0.0"), port); //3
				byte[] data = client.Receive(ref anyIP); //4

				string text = Encoding.UTF8.GetString(data); //5
				print(">> " + text);

				if (String.Equals(text, "straight"))
				{
					ejex = 0;
				}
				else if (String.Equals(text, "left"))
				{
					ejex = -1;
				}
				else if (String.Equals(text, "right"))
				{
					ejex = 1;
				}
				else
				{
					ejex = 0;
				}

			}
			catch (Exception e)
			{
				print(e.ToString()); //7
			}
		}
	}


	void Update()
	{
		transform.Rotate(ejex * rotationSpeed);
		/*if( transform.eulerAngles.y > -90 && transform.eulerAngles.y < 90 ){	
        			
        }else{
        	transform.eulerAngles = new Vector3(0, 0, 0);
        }
        */
		print(transform.eulerAngles.y);
	}
}
