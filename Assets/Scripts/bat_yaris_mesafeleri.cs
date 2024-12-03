using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityEngine.Rendering.Universal
{

    public class bat_yaris_mesafeleri : MonoBehaviour
{
    public GameObject canvas, Finish;
    // Use this for initialization
    void Start()
    {
        Finish = GameObject.FindGameObjectWithTag("Finish");
       
      
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition.x < 800)
        {
            transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition = new Vector3(((canvas.GetComponent<oyunici>().player.transform.GetChild(0).position.x / Finish.transform.GetChild(0).position.x) * 800)+(-24), -15.9F, 0);
        }
        if (transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition.x < 800)
        {
            transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector3(((canvas.GetComponent<oyunici>()._4PModeCars[0].transform.GetChild(0).position.x / Finish.transform.GetChild(0).position.x) * 800)+(-24), -15.9F, 0);
        }
   
        if (transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition.x < 800)
        {
            transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector3(((canvas.GetComponent<oyunici>()._4PModeCars[1].transform.GetChild(0).position.x / Finish.transform.GetChild(0).position.x) * 800)+(-24), -15.9F, 0);
        }
  
        if (transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition.x < 800)
        {
            
            transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector3(((canvas.GetComponent<oyunici>()._4PModeCars[2].transform.GetChild(0).position.x / Finish.transform.GetChild(0).position.x) * 800)+(-24), -15.9F, 0);
        }
    
    }
}
}
