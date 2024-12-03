using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class particle_ekle : MonoBehaviour {
    public GameObject Canvas;
    // Use this for initialization

    void OnEnable()
    {
        Canvas = GameObject.Find("Canvas");

        //if (PlayerPrefs.GetInt("Oyun_modu") == 6)
        //{
        //    if (PlayerPrefs.GetInt("Tur") != 5)
        //        gameObject.SetActive(false);
        //}
        //else {
        //    gameObject.SetActive(false);
        //}
      
         //  transform.position = new Vector3(transform.position.x, transform.position.y, Canvas.GetComponent<oyunici>().spawn_vs_1.transform.position.z);
     
    }
    private void Start()
    {
        //Canvas = GameObject.Find("Canvas");
    }

    public void LateUpdate()
    {
        Vector3 fwd = Vector3.down;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            if (hit.transform.gameObject.layer == 10)
            {
                transform.position = new Vector3(transform.position.x, hit.point.y + 0.35f, transform.position.z);
                Debug.DrawLine(transform.position, hit.point);
            }
        }
        else
        {

        }
    }

    void OnTriggerEnter(Collider other)
    {
       
            if ((other.gameObject.layer == 8 || other.gameObject.layer == 9 || other.gameObject.layer == 1) )
            {
                Canvas.GetComponent<oyunici>().toplanan_particle.transform.GetChild(1).GetComponent<Text>().text = (int.Parse(Canvas.GetComponent<oyunici>().toplanan_particle.transform.GetChild(1).GetComponent<Text>().text) +1).ToString();
                Canvas.GetComponent<oyunici>().player.GetComponent<truckk_yeni>().coin_ses.GetComponent<AudioSource>().Play();
                gameObject.SetActive(false);
            }
       
    }
}
