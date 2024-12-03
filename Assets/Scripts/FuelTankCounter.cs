using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelTankCounter : MonoBehaviour
{
    public GameObject canvas;

    public float maxSpeed; // The maximum speed of the target ** IN KM/H **

    public float minSpeedArrowAngle;
    public float maxSpeedArrowAngle;

    [Header("UI")]
    public Text FuelTankCounterText; // The label that displays the speed;
    public RectTransform arrow; // The arrow in the speedometer

    private float speed = 0.0f;
    public void Start()
    {
        canvas = GameObject.Find("Canvas");
    }
    private void Update()
    {
        // 3.6f to convert in kilometers
        // ** The speed must be clamped by the car controller **
        // speed = canvas.GetComponent<oyunici>().player.GetComponent<Rigidbody>().velocity.magnitude * 5;
          speed = canvas.GetComponent<oyunici>().player.GetComponent<truckk_yeni>().Benzin;

         if (FuelTankCounterText != null)
          FuelTankCounterText.text ="%"+ ((int)canvas.GetComponent<oyunici>().player.GetComponent<truckk_yeni>().Benzin);
        if (arrow != null)
            arrow.localEulerAngles =
               new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, canvas.GetComponent<oyunici>().player.GetComponent<truckk_yeni>().Benzin / maxSpeed));
    }
}
