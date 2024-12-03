using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class benzin : MonoBehaviour
{
    public GameObject Canvas;
    public static bool gameOver;
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        gameOver = false;
        if (PlayerPrefs.GetInt("Oyun_modu") == 6)
            if (PlayerPrefs.GetInt("Tur") == 4)
            {
                gameObject.SetActive(false);
            }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 fwd = Vector3.down;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit , 1000f))
        {
            if (hit.transform.gameObject.layer != 8 && hit.transform.gameObject.layer != 9 && hit.transform.gameObject.layer != 11 && hit.transform.gameObject.layer != 0)
            {
                transform.position = new Vector3(transform.position.x, hit.point.y + 0.5f, transform.position.z);
                Debug.DrawLine(transform.position, hit.point);
                if (hit.transform.gameObject.layer == 17)
                {
                    transform.position = new Vector3(transform.position.x + 2, hit.point.y + 0.5f, transform.position.z);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer == 8 || other.gameObject.layer == 9 || other.gameObject.layer == 11) && (other.transform.tag == "Player" || other.transform.parent.tag == "Player") && !gameOver)
        {
            Canvas.GetComponent<oyunici>().player.GetComponent<truckk_yeni>().Benzin = 100;
            Canvas.GetComponent<oyunici>().player.GetComponent<truckk_yeni>().benzin_ses.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
            gameOver = true;

            if (Canvas.GetComponent<oyunici>().tutorialcounter == 3 && !Canvas.GetComponent<oyunici>().gas_ust.activeSelf)
            {
                Canvas.GetComponent<oyunici>().player.GetComponentInParent<truckk_yeni>().physicMaterial.dynamicFriction = Canvas.GetComponent<oyunici>().player.gameObject.GetComponentInParent<truckk_yeni>().dynamicFrictionValue / 35;
                Canvas.GetComponent<oyunici>().gas_ust.SetActive(true);
                Canvas.GetComponent<oyunici>().tutorialcounter += 1;
            }
        }
    }
}
