using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class moveVirtualPhone : MonoBehaviour
{
    public GameObject NetworkManager;
    // TextMeshProUGUI speedText;
    // Start is called before the first frame update
    void Start()
    {
        //speedText = GameObject.Find("CartSpeed").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(NetworkManager.GetComponent<NetworkManagerTutorial>().numPlayers != 0)
        {
            this.GetComponent<RotateOnAxis>().rotate = false;
            float fromGyro = GameObject.Find("Sphere(Clone)").GetComponent<MoveGear>().plainSpeed.x;
            transform.rotation = new Quaternion(fromGyro, transform.rotation.y, transform.rotation.z, transform.rotation.w);

            //transform.Rotate(new Vector3(float.Parse(speedText.text)*0.2f,0,0));
        }
    }
}
