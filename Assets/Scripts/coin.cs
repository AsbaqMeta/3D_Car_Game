using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class coin : MonoBehaviour
{
    public GameObject Canvas;
    float goldToCarDistance;
    //public GameObject[] puan_text;

    // Use this for initialization
    public int whatCoin;
    private void Start()
    {
          InvokeRepeating("CoinRaycast",2f,3f);
    }
 
    void OnEnable()
    {
        girdi = true;
        Canvas = GameObject.Find("Canvas");
       
    }

    void CoinRaycast()
    {
        Vector3 fwd = Vector3.down;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            if (hit.transform.gameObject.layer == 10)
            {
                transform.position = new Vector3(transform.position.x, hit.point.y + 0.7f, transform.position.z);
                gameObject.GetComponent<Rigidbody>().freezeRotation = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y, Canvas.GetComponent<oyunici>().spawn_vs_1.transform.position.z);
        goldToCarDistance = Vector3.Distance(transform.position, Canvas.GetComponent<oyunici>().player.transform.position);

        if (goldToCarDistance < 7 && Canvas.GetComponent<oyunici>().MagnetClick)
        {

            this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, Canvas.GetComponent<oyunici>().player.transform.GetChild(0).transform.position, Time.deltaTime*Canvas.GetComponent<oyunici>().player.GetComponent<Rigidbody>().velocity.x);
        }

        


    }
    WaitForSeconds bekk = new WaitForSeconds(0.1f);
    IEnumerator yaz()
    {
        if (whatCoin == 5)
        {
            for (int i = 0; i >= 0; i--)
            {
                Canvas.GetComponent<oyunici>().puan += 5;
                yield return bekk;
            }
        }
        else if (whatCoin == 10)
        {
            for (int i = 0; i >= 0; i--)
            {
                Canvas.GetComponent<oyunici>().puan += 10;
                yield return bekk;
            }
        }
        else if (whatCoin == 25)
        {
            for (int i = 0; i >= 0; i--)
            {
                Canvas.GetComponent<oyunici>().puan += 25;
                yield return bekk;
            }
        }
        else if (whatCoin == 50)
        {
            for (int i = 0; i >= 0; i--)
            {
                Canvas.GetComponent<oyunici>().puan += 50;
                yield return bekk;
            }
        }
        else if (whatCoin == 100)
        {
            for (int i = 0; i >= 0; i--)
            {
                Canvas.GetComponent<oyunici>().puan += 100;
                yield return bekk;
            }
        }
        else if (whatCoin == 200)
        {
            for (int i = 0; i >= 0; i--)
            {
                Canvas.GetComponent<oyunici>().puan += 200;
                yield return bekk;
            }
        }
        else if (whatCoin == 500)
        {
            for (int i = 0; i >= 0; i--)
            {
                Canvas.GetComponent<oyunici>().puan += 500;
                yield return bekk;
            }
        }
        else
        {
            yield return bekk;
        }
        girdi = true;
    }

    bool girdi;
    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer == 11 ||other.gameObject.layer == 9 || other.gameObject.layer == 8 || other.gameObject.layer == 9 || other.gameObject.layer == 1 || other.gameObject.layer == 22) && girdi)
        {
            girdi = false;
            StartCoroutine(yaz());
            Canvas.GetComponent<oyunici>().wonCoinText.transform.parent.GetComponent<Animation>().Play();
           // Canvas.GetComponent<oyunici>().toplanan_particle.transform.GetChild(1).GetComponent<Text>().text = (int.Parse(Canvas.GetComponent<oyunici>().toplanan_particle.transform.GetChild(1).GetComponent<Text>().text) + 1).ToString();
            GameObject.Instantiate(Canvas.GetComponent<oyunici>().coinSpawnObject, transform.position, Quaternion.identity);
            Canvas.GetComponent<oyunici>().coinSpawnObject.transform.GetChild(0).GetComponent<Animation>().Play();
            this.gameObject.SetActive(false);
            Canvas.GetComponent<oyunici>().player.GetComponent<truckk_yeni>().coin_ses.GetComponent<AudioSource>().Play();

            // Increment the Score of the Game in Firebase Database
            DataManager.totalExp += 1;
            DatabaseManager.Instance.SaveandUpdateUserData();
        }
        else
        {

        }
    }

}
