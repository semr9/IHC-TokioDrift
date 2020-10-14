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
	Rigidbody rb;
    float currentValue;
	public TextMeshProUGUI TextSpeedBar;
	public Text TextTopSpeed;
	public TextMeshProUGUI TextVoiceCommand;
	public GameObject kart;
    // Start is called before the first frame update
    void Start()
    {
		rb = kart.GetComponent<Rigidbody>();
    }
	/// maxAngle -- maxSpeed
	/// idk -- kart.GetComponent<Rigidbody>().velocity.magnitude
	/// idk == kart.GetComponent<Rigidbody>().velocity.magnitude * maxAngle / maxSpeed

	void Update()
	{
		currentValue = rb.velocity.magnitude;
		TextSpeedBar.text = currentValue.ToString("0");
		if (TextVoiceCommand.text == "turbo activado") maxAngle = 0.58f; else maxAngle = 0.5f;
		float fillAmount = currentValue * maxAngle / float.Parse(TextTopSpeed.text);
		if (fillAmount < minAngle) fillAmount = minAngle;
		else if (fillAmount > maxAngle) fillAmount = maxAngle;
		SpeedBarImg.fillAmount = fillAmount;
	}
}
