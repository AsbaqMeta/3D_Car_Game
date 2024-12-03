using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vs_yaris_mesafeleri : MonoBehaviour {
    public GameObject canvas,Finish;
	// Use this for initialization
	void Start () {
        

        
       
    }

    // Update is called once per frame
    void Update()
    {
        //  Debug.Log("finish" + Finish.transform.GetChild(0).position.x);
        //  Debug.Log("player" + canvas.GetComponent<oyunici>().player.transform.GetChild(0).position.x);

        if (Finish == null)
        {

            Finish = GameObject.FindGameObjectWithTag("Finish");
        }
        else if(canvas.GetComponent<oyunici>()._2PModeBotCar)
        {
            if (transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition.x < 800)
            {
                transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector3((((canvas.GetComponent<oyunici>().player.transform.GetChild(0).position.x) / Finish.transform.GetChild(0).position.x) * 800)+(-24), -15.9f, 0);
            }

            if (transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition.x < 800)
            {
                transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector3((((canvas.GetComponent<oyunici>()._2PModeBotCar.transform.GetChild(0).position.x) / Finish.transform.GetChild(0).position.x) * 800)+(-24), -15.9f, 0);
            }
        }
    }
}
