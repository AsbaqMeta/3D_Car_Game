using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class mesafe_uzun : MonoBehaviour
{

    public GameObject canvas;
    public Text mesafe;
    public int sayi;
    public int deger;
    public int dist;
    public int coinss;
    public Text distanceCompletedText, travelDistanceText;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        deger = 1;
        dist = 250;
        coinss = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.root.GetComponent<oyunici>().player)
        {
            sayi = (int)transform.root.GetComponent<oyunici>().player.transform.GetChild(0).position.x;


        }

    }

    void FixedUpdate()
    {

        if (canvas.GetComponent<oyunici>().Scene_val == 1)
        {
            if (sayi >= PlayerPrefs.GetInt("laspositionmap1"))
            {

                PlayerPrefs.SetInt("laspositionmap1", PlayerPrefs.GetInt("laspositionmap1") + 250);
                PlayerPrefs.SetInt("distancecoinmap1", PlayerPrefs.GetInt("distancecoinmap1") + 3500);
                distanceCompletedText.text = "Distance Completed! Bonus: +" + PlayerPrefs.GetInt("distancecoinmap1");
                travelDistanceText.text = "Travel Distance: " + PlayerPrefs.GetInt("laspositionmap1") + " mt";
                distanceCompletedText.GetComponent<Animation>().Play();
                travelDistanceText.GetComponent<Animation>().Play();
                canvas.GetComponent<oyunici>().distancecoinss += PlayerPrefs.GetInt("distancecoinmap1");

            }
            transform.GetComponent<Text>().text = ((int)(canvas.GetComponent<oyunici>().Chassis.transform.position.x - canvas.GetComponent<oyunici>().ilk_pos.x)) + " M / " + PlayerPrefs.GetInt("laspositionmap1") + " M ";
        }

        else if (canvas.GetComponent<oyunici>().Scene_val == 2)
        {
            if (sayi >= PlayerPrefs.GetInt("laspositionmap2"))
            {
                PlayerPrefs.SetInt("laspositionmap2", PlayerPrefs.GetInt("laspositionmap2") + 300);
                PlayerPrefs.SetInt("distancecoinmap2", PlayerPrefs.GetInt("distancecoinmap2") + 5000);
                distanceCompletedText.text = "Distance Completed! Bonus: +" + PlayerPrefs.GetInt("distancecoinmap2");
                travelDistanceText.text = "Travel Distance: " + PlayerPrefs.GetInt("laspositionmap2") + " mt";
                distanceCompletedText.GetComponent<Animation>().Play();
                travelDistanceText.GetComponent<Animation>().Play();
                canvas.GetComponent<oyunici>().distancecoinss += PlayerPrefs.GetInt("distancecoinmap2");
            }
            transform.GetComponent<Text>().text =  ((int)(canvas.GetComponent<oyunici>().Chassis.transform.position.x - canvas.GetComponent<oyunici>().ilk_pos.x)) + " M / " + PlayerPrefs.GetInt("laspositionmap2") + " M "; ;

        }



        else if (canvas.GetComponent<oyunici>().Scene_val == 3)
        {
            if (sayi >= PlayerPrefs.GetInt("laspositionmap3"))
            {
                PlayerPrefs.SetInt("laspositionmap3", PlayerPrefs.GetInt("laspositionmap3") + 350);
                PlayerPrefs.SetInt("distancecoinmap3", PlayerPrefs.GetInt("distancecoinmap3") + 7500);
                distanceCompletedText.text = "Distance Completed! Bonus: +" + PlayerPrefs.GetInt("distancecoinmap3");
                travelDistanceText.text = "Travel Distance: " + PlayerPrefs.GetInt("laspositionmap1") + " mt";
                distanceCompletedText.GetComponent<Animation>().Play();
                travelDistanceText.GetComponent<Animation>().Play();
                canvas.GetComponent<oyunici>().distancecoinss += PlayerPrefs.GetInt("distancecoinmap3");

            }
            transform.GetComponent<Text>().text =  ((int)(canvas.GetComponent<oyunici>().Chassis.transform.position.x - canvas.GetComponent<oyunici>().ilk_pos.x)) + " M / " + PlayerPrefs.GetInt("laspositionmap3") + " M ";
        }


        else if (canvas.GetComponent<oyunici>().Scene_val == 4)
        {
            if (sayi >= PlayerPrefs.GetInt("laspositionmap4"))
            {
                PlayerPrefs.SetInt("laspositionmap4", PlayerPrefs.GetInt("laspositionmap4") + 400);
                PlayerPrefs.SetInt("distancecoinmap4", PlayerPrefs.GetInt("distancecoinmap4") + 7000);
                distanceCompletedText.text = "Distance Completed! Bonus: +" + PlayerPrefs.GetInt("distancecoinmap1");
                travelDistanceText.text = "Travel Distance: " + PlayerPrefs.GetInt("laspositionmap1") + " mt";
                distanceCompletedText.GetComponent<Animation>().Play();
                travelDistanceText.GetComponent<Animation>().Play();
                canvas.GetComponent<oyunici>().distancecoinss += PlayerPrefs.GetInt("distancecoinmap4");
            }
            transform.GetComponent<Text>().text =  ((int)(canvas.GetComponent<oyunici>().Chassis.transform.position.x - canvas.GetComponent<oyunici>().ilk_pos.x)) + " M / " + PlayerPrefs.GetInt("laspositionmap4") + " M ";
        }


        else if (canvas.GetComponent<oyunici>().Scene_val == 5)
        {
            if (sayi >= PlayerPrefs.GetInt("laspositionmap5"))
            {
                PlayerPrefs.SetInt("laspositionmap5", PlayerPrefs.GetInt("laspositionmap5") + 500);
                PlayerPrefs.SetInt("distancecoinmap5", PlayerPrefs.GetInt("distancecoinmap5") + 5000);
                distanceCompletedText.text = "Distance Completed! Bonus: +" + PlayerPrefs.GetInt("distancecoinmap1");
                travelDistanceText.text = "Travel Distance: " + PlayerPrefs.GetInt("laspositionmap1") + " mt";
                distanceCompletedText.GetComponent<Animation>().Play();
                travelDistanceText.GetComponent<Animation>().Play();
                canvas.GetComponent<oyunici>().distancecoinss += PlayerPrefs.GetInt("distancecoinmap5");
            }
            transform.GetComponent<Text>().text =  ((int)(canvas.GetComponent<oyunici>().Chassis.transform.position.x - canvas.GetComponent<oyunici>().ilk_pos.x)) + " M / " + PlayerPrefs.GetInt("laspositionmap5") + " M ";
        }
        else
        {
            transform.GetComponent<Text>().text = ((int)(canvas.GetComponent<oyunici>().Chassis.transform.position.x - canvas.GetComponent<oyunici>().ilk_pos.x)) + " M";

        }
    }
}
