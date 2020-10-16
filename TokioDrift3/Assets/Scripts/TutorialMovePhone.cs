using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovePhone : MonoBehaviour
{
    public int state;
    public GameObject NetworkManager;
    Vector3 rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = new Vector3(0.2f, 0.0f, 0.0f);
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(NetworkManager.GetComponent<NetworkManagerTutorial>().numPlayers != 0)
        {
            //float fromGyro = GameObject.Find("Sphere(Clone)").GetComponent<MoveGear>().speed.y;
            if (state == 0) { // move up
                if (transform.rotation.x >= 0.5f)
                    transform.Rotate(new Vector3(-90.0f, 0.0f, 0.0f));
                transform.Rotate(new Vector3(0.2f, 0.0f, 0.0f));
            } else if(state == 1) { // move down
                if (transform.rotation.x <= -0.5f)
                    transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f));
                transform.Rotate(new Vector3(-0.2f, 0.0f, 0.0f));
            } else if(state == 2) { // move straight
                transform.rotation = new Quaternion(0, 90.0f, 0, 0);
            }
        } else {
            if (transform.rotation.x >= 0.5f || transform.rotation.x <= -0.5f)
                rotationSpeed.x = -rotationSpeed.x;
            transform.Rotate(rotationSpeed);
        }
    }
}
