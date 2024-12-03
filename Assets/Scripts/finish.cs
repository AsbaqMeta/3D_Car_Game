using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class finish : MonoBehaviour
    {

        public int finishcounter;
        public int counter2;

        // Use this for initialization
        void Start()
        {
            finishcounter = 0;
            counter2 = 0;
            Canvass = GameObject.Find("Canvas");

            Canvass.GetComponent<oyunici>().startTime1 = Time.time;
            Canvass.GetComponent<oyunici>().startTime2 = Time.time;
            Canvass.GetComponent<oyunici>().startTime3 = Time.time;
            Canvass.GetComponent<oyunici>().startTime4 = Time.time;
        }
        public GameObject Canvass;
        // Update is called once per frame
        void Update()
        {
            if (finishcounter < 1)
            {
                Canvass.GetComponent<oyunici>().t1 = Time.time - Canvass.GetComponent<oyunici>().startTime1;
            }
            if (finishcounter < 2)
            {
                Canvass.GetComponent<oyunici>().t2 = Time.time - Canvass.GetComponent<oyunici>().startTime2;
            }
            if (finishcounter < 3)
            {
                Canvass.GetComponent<oyunici>().t3 = Time.time - Canvass.GetComponent<oyunici>().startTime3;
            }
            if (finishcounter < 4)
            {
                Canvass.GetComponent<oyunici>().t4 = Time.time - Canvass.GetComponent<oyunici>().startTime4;
            }

        }
        bool once = true;
        void OnTriggerEnter(Collider other)
        {
            if (PlayerPrefs.GetInt("Oyun_modu") == 6)
            {
                if (once && other.gameObject.tag == "Player")
                {
               
                    Canvass.GetComponent<oyunici>().GetComponent<Canvas>().enabled = false;
                    oyunici.deadZoom = true;
                    GetComponent<AudioSource>().enabled = true;
                    GetComponent<AudioSource>().Play();
                    StartCoroutine(finishedd());
                    once = false;
                }

            }





            if (PlayerPrefs.GetInt("Oyun_modu") == 2)
            {
                if (other.gameObject.tag == "Player")
                {
                    if (finishcounter == 0)
                    {
                        if (once)
                        {
                            Canvass.GetComponent<oyunici>()._4PModePlayerName1Text.text = PlayerPrefs.GetString("OyuncuAdi");

                            for (int x = 0; x < 7; x++)
                            {
                                Canvass.GetComponent<oyunici>().res1_bat.transform.GetChild(x).gameObject.SetActive(false);
                                Canvass.GetComponent<oyunici>().res2_bat.transform.GetChild(x).gameObject.SetActive(false);
                                Canvass.GetComponent<oyunici>().res3_bat.transform.GetChild(x).gameObject.SetActive(false);
                                Canvass.GetComponent<oyunici>().res4_bat.transform.GetChild(x).gameObject.SetActive(false);
                            }
                            Canvass.GetComponent<oyunici>().res1_bat.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).gameObject.SetActive(true);
                            Canvass.GetComponent<oyunici>().res2_bat.transform.GetChild(Random.Range(0, 7)).gameObject.SetActive(true);
                            Canvass.GetComponent<oyunici>().res3_bat.transform.GetChild(Random.Range(0, 7)).gameObject.SetActive(true);
                            Canvass.GetComponent<oyunici>().res4_bat.transform.GetChild(Random.Range(0, 7)).gameObject.SetActive(true);


                            Canvass.GetComponent<oyunici>().GetComponent<Canvas>().enabled = false;
                            oyunici.deadZoom = true;
                            GetComponent<AudioSource>().enabled = true;
                            GetComponent<AudioSource>().Play();
                            StartCoroutine(finishedd());
                            once = false;
                            finishcounter += 1;
                        }
                    }
                    if (finishcounter == 1)
                    {
                        if (once)
                        {
                            Canvass.GetComponent<oyunici>()._4PModePlayerName2Text.text = PlayerPrefs.GetString("OyuncuAdi");

                            for (int x = 0; x < 7; x++)
                            {
                                Canvass.GetComponent<oyunici>().res1_bat.transform.GetChild(x).gameObject.SetActive(false);
                                Canvass.GetComponent<oyunici>().res2_bat.transform.GetChild(x).gameObject.SetActive(false);
                                Canvass.GetComponent<oyunici>().res3_bat.transform.GetChild(x).gameObject.SetActive(false);
                                Canvass.GetComponent<oyunici>().res4_bat.transform.GetChild(x).gameObject.SetActive(false);
                            }
                            Canvass.GetComponent<oyunici>().res1_bat.transform.GetChild(Random.Range(0, 7)).gameObject.SetActive(true);
                            Canvass.GetComponent<oyunici>().res2_bat.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).gameObject.SetActive(true);
                            Canvass.GetComponent<oyunici>().res3_bat.transform.GetChild(Random.Range(0, 7)).gameObject.SetActive(true);
                            Canvass.GetComponent<oyunici>().res4_bat.transform.GetChild(Random.Range(0, 7)).gameObject.SetActive(true);

                            Canvass.GetComponent<oyunici>().res2_bat.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).gameObject.SetActive(true);
                            Debug.Log("2. Araba Player");
                            Canvass.GetComponent<oyunici>().GetComponent<Canvas>().enabled = false;
                            oyunici.deadZoom = true;
                            GetComponent<AudioSource>().enabled = true;
                            GetComponent<AudioSource>().Play();
                            StartCoroutine(finishedd());
                            once = false;
                            finishcounter += 1;
                        }

                    }
                    if (finishcounter == 2)
                    {
                        if (once)
                        {
                            Canvass.GetComponent<oyunici>()._4PModePlayerName3Text.text = PlayerPrefs.GetString("OyuncuAdi");

                            for (int x = 0; x < 7; x++)
                            {
                                Canvass.GetComponent<oyunici>().res1_bat.transform.GetChild(x).gameObject.SetActive(false);
                                Canvass.GetComponent<oyunici>().res2_bat.transform.GetChild(x).gameObject.SetActive(false);
                                Canvass.GetComponent<oyunici>().res3_bat.transform.GetChild(x).gameObject.SetActive(false);
                                Canvass.GetComponent<oyunici>().res4_bat.transform.GetChild(x).gameObject.SetActive(false);
                            }
                            Canvass.GetComponent<oyunici>().res1_bat.transform.GetChild(Random.Range(0, 7)).gameObject.SetActive(true);
                            Canvass.GetComponent<oyunici>().res2_bat.transform.GetChild(Random.Range(0, 7)).gameObject.SetActive(true);
                            Canvass.GetComponent<oyunici>().res3_bat.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).gameObject.SetActive(true);
                            Canvass.GetComponent<oyunici>().res4_bat.transform.GetChild(Random.Range(0, 7)).gameObject.SetActive(true);
                            Canvass.GetComponent<oyunici>().GetComponent<Canvas>().enabled = false;
                            oyunici.deadZoom = true;
                            GetComponent<AudioSource>().enabled = true;
                            GetComponent<AudioSource>().Play();
                            StartCoroutine(finishedd());
                            once = false;
                            finishcounter += 1;
                        }

                    }
                    if (finishcounter == 3)
                    {
                        if (once)
                        {
                            Canvass.GetComponent<oyunici>()._4PModePlayerName4Text.text = PlayerPrefs.GetString("OyuncuAdi");

                            for (int x = 0; x < 7; x++)
                            {
                                Canvass.GetComponent<oyunici>().res1_bat.transform.GetChild(x).gameObject.SetActive(false);
                                Canvass.GetComponent<oyunici>().res2_bat.transform.GetChild(x).gameObject.SetActive(false);
                                Canvass.GetComponent<oyunici>().res3_bat.transform.GetChild(x).gameObject.SetActive(false);
                                Canvass.GetComponent<oyunici>().res4_bat.transform.GetChild(x).gameObject.SetActive(false);
                            }
                            Canvass.GetComponent<oyunici>().res1_bat.transform.GetChild(Random.Range(0, 7)).gameObject.SetActive(true);
                            Canvass.GetComponent<oyunici>().res2_bat.transform.GetChild(Random.Range(0, 7)).gameObject.SetActive(true);
                            Canvass.GetComponent<oyunici>().res3_bat.transform.GetChild(Random.Range(0, 7)).gameObject.SetActive(true);
                            Canvass.GetComponent<oyunici>().res4_bat.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).gameObject.SetActive(true);
                            Canvass.GetComponent<oyunici>().GetComponent<Canvas>().enabled = false;
                            oyunici.deadZoom = true;
                            GetComponent<AudioSource>().enabled = true;
                            GetComponent<AudioSource>().Play();
                            StartCoroutine(finishedd());
                            once = false;
                            finishcounter += 1;
                        }

                    }




                }
                if (other.gameObject.tag == "yapay")
                {
                    if (finishcounter == 0)
                    {
                        for (int i = 0; i < 10; i++)
                        {

                            if (other.transform.parent.GetComponent<truckk_yeni>().carID == i && once)
                            {
                                Debug.Log("1. Arabanın ID'si" + i);
                                counter2 = i;
                                finishcounter += 1;
                            }
                        }
                    }

                    if (finishcounter == 1)
                    {
                        for (int i = 0; i < 10; i++)
                        {

                            if (other.transform.parent.GetComponent<truckk_yeni>().carID == i && other.transform.parent.GetComponent<truckk_yeni>().carID != counter2)
                            {
                                Debug.Log("2. Arabanın ID'si" + i);
                                counter2 = i;
                                finishcounter += 1;
                            }
                        }
                    }
                    if (finishcounter == 2)
                    {
                        for (int i = 0; i < 10; i++)
                        {

                            if (other.transform.parent.GetComponent<truckk_yeni>().carID == i && other.transform.parent.GetComponent<truckk_yeni>().carID != counter2)
                            {
                                Debug.Log("3. Arabanın ID'si" + i);
                                counter2 = i;
                                finishcounter += 1;
                            }
                        }
                    }
                    if (finishcounter == 3)
                    {
                        for (int i = 0; i < 10; i++)
                        {

                            if (other.transform.parent.GetComponent<truckk_yeni>().carID == i && other.transform.parent.GetComponent<truckk_yeni>().carID != counter2)
                            {
                                Debug.Log("4. Arabanın ID'si" + i);
                                counter2 = i;
                                finishcounter += 1;
                            }
                        }
                    }
                }
            }


            if (PlayerPrefs.GetInt("Oyun_modu") == 1)
            {
                if (other.gameObject.tag == "Player")
                {
                    if (finishcounter == 0)
                    {
                        if (once)
                        {
                            Canvass.GetComponent<oyunici>()._2PModePlayerName1Text.text = PlayerPrefs.GetString("OyuncuAdi");
                            for (int x = 0; x < Canvass.GetComponent<oyunici>().res1_vs.transform.childCount; x++)
                            {
                                Canvass.GetComponent<oyunici>().res1_vs.transform.GetChild(x).gameObject.SetActive(false);
                            }
                            Canvass.GetComponent<oyunici>().res1_vs.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).gameObject.SetActive(true);
                            for (int i = 0; i < Canvass.GetComponent<oyunici>().res2_vs.transform.childCount; i++)
                            {
                                Canvass.GetComponent<oyunici>().res2_vs.transform.GetChild(i).gameObject.SetActive(false);
                            }
                            Canvass.GetComponent<oyunici>().res2_vs.transform.GetChild(Random.Range(0, 7)).gameObject.SetActive(true);
                            Canvass.GetComponent<oyunici>().GetComponent<Canvas>().enabled = false;
                            oyunici.deadZoom = true;
                            GetComponent<AudioSource>().enabled = true;
                            GetComponent<AudioSource>().Play();
                            StartCoroutine(finishedd());
                            once = false;
                            finishcounter += 1;
                        }

                    }
                    if (finishcounter == 1)
                    {
                        if (once)
                        {
                            Canvass.GetComponent<oyunici>()._2PModePlayerName2Text.text = PlayerPrefs.GetString("OyuncuAdi");
                            for (int x = 0; x < Canvass.GetComponent<oyunici>().res2_vs.transform.childCount; x++)
                            {
                                Canvass.GetComponent<oyunici>().res2_vs.transform.GetChild(x).gameObject.SetActive(false);
                            }
                            Canvass.GetComponent<oyunici>().res2_vs.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).gameObject.SetActive(true);

                            for (int i = 0; i < Canvass.GetComponent<oyunici>().res2_vs.transform.childCount; i++)
                            {
                                Canvass.GetComponent<oyunici>().res1_vs.transform.GetChild(i).gameObject.SetActive(false);
                            }
                            Canvass.GetComponent<oyunici>().res1_vs.transform.GetChild(Random.Range(0, 7)).gameObject.SetActive(true);

                            Canvass.GetComponent<oyunici>().GetComponent<Canvas>().enabled = false;
                            oyunici.deadZoom = true;
                            GetComponent<AudioSource>().enabled = true;
                            GetComponent<AudioSource>().Play();
                            StartCoroutine(finishedd());
                            once = false;
                            finishcounter += 1;
                        }

                    }

                }
                if (other.gameObject.tag == "yapay")
                {
                    if (finishcounter == 0)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (other.transform.parent.GetComponent<truckk_yeni>().carID == i && once)
                            {
                                counter2 = i;
                                finishcounter += 1;
                            }
                        }
                    }

                    if (finishcounter == 1)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (other.transform.parent.GetComponent<truckk_yeni>().carID == i && other.transform.parent.GetComponent<truckk_yeni>().carID != counter2)
                            {
                                counter2 = i;
                                finishcounter += 1;
                            }
                        }
                    }
                }
            }

        }

        IEnumerator finishedd()
        {
            yield return new WaitForSecondsRealtime(1.5f);
            var audioListener = FindObjectsOfType<AudioSource>();
            truckk_yeni.finishFren = true;

            for (int i = 0; i < audioListener.Length; i++)
            {
                audioListener[i].Stop();
            }
            Canvass.GetComponent<oyunici>().finished = true;
        }

    }
