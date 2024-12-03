using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class air_time : MonoBehaviour
{
    float bas_nok;
    bool battle, Player;
    public GameObject canvas;
    public Text airtime;
    public float time, time2;
    public Coroutine bitir;
    bool once = true;
    public static bool carAir;
    public GameObject x1, x2, x3, airtimex, bigair;
    float alpha = 1;
    bool ibo, ibo2, ibo3;
    int degisken = 0, temp_degisken = 0;
    public GameObject TransitionSound;
    void Awake()
    {
        x1 = GameObject.FindGameObjectWithTag("x1");
        x2 = GameObject.FindGameObjectWithTag("x2");
        x3 = GameObject.FindGameObjectWithTag("x3");
        airtimex = GameObject.FindGameObjectWithTag("airtimex");
        bigair = GameObject.FindGameObjectWithTag("bigair");
    }
    void Start()
    {
        TransitionSound = GameObject.Find("TransitionSound");
        x1.GetComponent<Image>().enabled = true;
        x2.GetComponent<Image>().enabled = true;
        x3.GetComponent<Image>().enabled = true;
        airtimex.GetComponent<Image>().enabled = true;
        bigair.GetComponent<Image>().enabled = true;
        ibo = true;
        canvas = GameObject.Find("Canvas");

        bas_nok = transform.position.z + 0.2f;
        if (PlayerPrefs.GetInt("Oyun_modu") == 2)
        {
            battle = true;
        }
        if (transform.parent.parent.GetChild(0).tag == "Player")
        {
            Player = true;
        }
        canvas.GetComponent<oyunici>().airTimeCounter = 0;
    }

    void LateUpdate()
    {
        if (time > 1f)
        {
            time2 += Time.deltaTime;
        }
        if (time2 >= 1)
        {
            /*  x3.SetActive(true);
             x2.SetActive(false);
             x1.SetActive(false);
             airtimex.SetActive(false);
             bigair.SetActive(true); */
            time2 = 0;
        }
        if (transform.parent.parent.GetChild(0).tag == "Player")
        {
            Vector3 fwd = Vector3.down;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, fwd, out hit, 10))
            {

                if (Vector3.Distance(transform.position, hit.point) > 0.5f)
                {
                    carAir = true;
                }

                else
                {
                    carAir = false;
                }
            }

            if (airtime == null)
            {
                airtime = GameObject.FindGameObjectWithTag("air_time").GetComponent<Text>();
            }
            else
            {
                if (Physics.Raycast(transform.position, fwd, out hit, 10))
                {

                    if (Vector3.Distance(transform.position, hit.point) > 0.9f)
                    {
                        if (bitir != null)
                        {
                            StopCoroutine(bitir);
                            once = true;
                        }
                        time += Time.deltaTime;
                        if (time > 0.25f && time < 0.27f)
                        {
                            canvas.GetComponent<oyunici>().airTimeCounter += 1;
                        }
                        if (time > 0.6f)
                        {
                            degisken = 1;
                        }
                        if (time > 1.2f)
                        {
                            degisken = 2;
                        }
                        if (time > 2f)
                        {
                            degisken = 3;
                        }
                    }
                    else
                    {
                        if (once)
                        {
                            degisken = 0;
                            bitir = StartCoroutine(bekle());
                            once = false;
                        }
                        airtime.text = time.ToString();
                    }
                    if (!battle)
                    {
                        if (Vector3.Distance(transform.position, hit.point) > 0.3f)
                        {
                            alpha = Mathf.Lerp(alpha, 0f, Time.deltaTime * 6);
                        }
                        else
                        {
                            alpha = Mathf.Lerp(alpha, 1f, Time.deltaTime * 6);
                        }
                    }
                }
            }

            if (temp_degisken != degisken && canvas.GetComponent<oyunici>().olme == false &&  canvas.GetComponent<oyunici>().benzindip==false )
            {
                if (PlayerPrefs.GetInt("BonusMap") != 0)
                {
                    temp_degisken = degisken;
                    if (degisken == 1 && ibo)
                    {
                        canvas.GetComponent<oyunici>().award += 25;
                        x2.SetActive(false);
                        x1.SetActive(true);

                        TransitionSound.GetComponent<AudioSource>().Play();
                        airtimex.transform.DOLocalRotate(new Vector3(0, 0, Random.Range(-35, 35)), 0.15f);
                        airtimex.transform.DOScale(new Vector3(.4f, .4f, .4f), 0.15f);
                        ibo = false;
                    }
                    if (degisken == 2 && ibo2)
                    {
                        canvas.GetComponent<oyunici>().award += 50;
                        x2.SetActive(true);
                        x1.SetActive(false);
                        ibo2 = false;
                    }

                    if (degisken == 3 && ibo3)
                    {
                        canvas.GetComponent<oyunici>().award += 75;
                        TransitionSound.GetComponent<AudioSource>().Play();
                        bigair.transform.DOLocalRotate(new Vector3(0, 0, Random.Range(-35, 35)), 0.15f);
                        bigair.transform.DOScale(new Vector3(.4f, .4f, .4f), 0.15f);
                        airtimex.transform.DOLocalRotate(new Vector3(0, 0, -150), 0.15f);
                        airtimex.transform.DOScale(new Vector3(0, 0, 0), 0.15f);
                        ibo3 = false;
                    }
                }


            }

        }
        else
        {

        }
    }
    IEnumerator bekle()
    {
        yield return new WaitForSeconds(0.5f);
        airtime.text = "";
        time = 0;
        airtimex.transform.DOLocalRotate(new Vector3(0, 0, -150), 0.15f);
        airtimex.transform.DOScale(new Vector3(0, 0, 0), 0.15f);
        bigair.transform.DOLocalRotate(new Vector3(0, 0, 150), 0.15f);
        bigair.transform.DOScale(new Vector3(0, 0, 0), 0.15f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "iboreis")
        {
            carAir = false;
            ibo = true;
            ibo2 = true;
            ibo3 = true;
            time2 = 0;
        }

    }
    private void OnCollisionExit(Collision other)
    {

        if (other.gameObject.tag == "iboreis")
        {
            carAir = true;
        }

    }


}
