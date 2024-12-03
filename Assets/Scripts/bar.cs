using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bar : MonoBehaviour {

    // Use this for initialization
    public static bool loadingRun=true;
    GameObject MainMenuScript;
    void Start ()
    {
        MainMenuScript = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void LateUpdate () {
        GetComponent<Image>().fillAmount = Mathf.MoveTowards(GetComponent<Image>().fillAmount, 1, Time.deltaTime * 0.2f);

        if (GetComponent<Image>().fillAmount == 1)
        {
            transform.parent.gameObject.SetActive(false);
            loadingRun=false;
            MainMenuScript.GetComponent<Mainmenu>().mainMenuPanel.SetActive(true);
        }
    }
}