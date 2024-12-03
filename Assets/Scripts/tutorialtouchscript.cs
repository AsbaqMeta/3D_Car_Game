using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialtouchscript : MonoBehaviour
{
    GameObject canvas;
    void Start()
    {
        canvas = GameObject.Find("Canvas");
    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            canvas.gameObject.GetComponent<oyunici>().tutorialcollidertouch = true;
            this.gameObject.SetActive(false);
            canvas.gameObject.GetComponent<oyunici>().player.GetComponent<truckk_yeni>().gas = false;
            canvas.gameObject.GetComponent<oyunici>().player.GetComponent<truckk_yeni>().fren = false;
            
        }
    }

}
