using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedBar : MonoBehaviour
{
	public float minAngle;
	public float maxAngle;
	public Image SpeedBarImg;
    float currentValue;
	public TextMeshProUGUI speedText;
	public GameObject kart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	void Update()
	{
		if (currentValue < 100)
		{
			currentValue = kart.GetComponent<Rigidbody>().velocity.magnitude;
			SpeedBarImg.fillAmount = currentValue / 100;
			speedText.text = currentValue.ToString("0");
		}
		else
		{
		}

	}
}
