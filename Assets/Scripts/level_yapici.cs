using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_yapici : MonoBehaviour
{
    public GameObject _carFollowCollider;
    public GameObject _canvas;
    public GameObject Level, ilk_seviye;
    public List<GameObject> seviye = new List<GameObject>();
    int seviyeilk;
    float temp_vel, temp_vel2;
    public int son = 0;
    int x = 0;

    void Start()
    {
        _carFollowCollider=GameObject.Find("CarFollowCollider");
        _canvas=GameObject.Find("Canvas");
        if ( (PlayerPrefs.GetInt("Oyun_modu") == 0 || (PlayerPrefs.GetInt("Oyun_modu") == 6 && PlayerPrefs.GetInt("Tur") != 2)))
        {
            Level = GameObject.FindGameObjectWithTag("level");
            ilk_seviye = GameObject.FindGameObjectWithTag("ilkseviye");
            for (int i = 0; i < Level.transform.childCount; i++)
            {
                seviye.Add(Level.transform.GetChild(i).gameObject);
                seviye[i].SetActive(false);
            }
            seviyeilk = Random.Range(0, Level.transform.childCount);
            seviye[seviyeilk].GetComponent<level_ic>().bas.transform.position = ilk_seviye.GetComponent<level_ic>().son.transform.position;
            seviye[seviyeilk].GetComponent<level_ic>().bas.transform.Rotate(new Vector3(0, 0, Random.Range(0f, 4f)));
            seviye[seviyeilk].SetActive(true);
            x = seviyeilk;
            InvokeRepeating("RaycastCounter", 2f,2f);
        }
    }

    void RaycastCounter()
    {
        if (PlayerPrefs.GetInt("Oyun_modu") == 0 || (PlayerPrefs.GetInt("Oyun_modu") == 6 && PlayerPrefs.GetInt("Tur") != 2))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1000f))
            {
                Debug.DrawRay(transform.position, Vector3.down * 100, Color.red);
                if (hit.transform.gameObject.layer == 10)
                {
                    for (int i = 0; i < seviye.Count; i++)
                    {
                        if (hit.transform.parent.parent.name == seviye[i].name)
                        {
                            if (son != i)
                            {
                                son = i;
                            }
                        }
                    }
                }
            }
        }

    }

    void Update()
    {

       
            this.gameObject.transform.position = new Vector3(_canvas.GetComponent<oyunici>().player.transform.position.x - 2, _canvas.GetComponent<oyunici>().player.transform.position.y + 8, _canvas.GetComponent<oyunici>().player.transform.position.z);
            /* if (seviye[son].GetComponent<level_ic>().bas.transform.position.y > gameObject.transform.parent.parent.gameObject.transform.position.y + 80)
            {
                //silme
                Debug.Log("aaaaagitti");

            } */
      //  }
    }

    public void spawn()
    {

        if (PlayerPrefs.GetInt("Oyun_modu") == 0 || (PlayerPrefs.GetInt("Oyun_modu") == 6 && PlayerPrefs.GetInt("Tur") != 2))
        {
            while (x == son)
            {
                x = Random.Range(0, Level.transform.childCount);
            }
            if (seviye[x].activeSelf)
            {
                for (int a = 0; a < seviye[x].GetComponent<spawner_ac>()._destroyedObject.transform.childCount; a++)
                {
                    Destroy(seviye[x].GetComponent<spawner_ac>()._destroyedObject.transform.GetChild(a).gameObject);
                }
            }
            seviye[x].SetActive(false);
            seviye[x].GetComponent<level_ic>().bas.transform.position = seviye[son].GetComponent<level_ic>().son.transform.position;
            if (oyunici.carDistanceCounter <= 250)
            {
                seviye[x].GetComponent<level_ic>().bas.transform.Rotate(new Vector3(0, 0, Random.Range(-1f, 6f)));
            }
            if (oyunici.carDistanceCounter <= 500)
            {
                seviye[x].GetComponent<level_ic>().bas.transform.Rotate(new Vector3(0, 0, Random.Range(-4f, 8f)));
            }
            if (oyunici.carDistanceCounter >= 500 && oyunici.carDistanceCounter <= 1000)
            {
                seviye[x].GetComponent<level_ic>().bas.transform.Rotate(new Vector3(0, 0, Random.Range(-8f, 11f)));
            }
            if (oyunici.carDistanceCounter >= 1000 && oyunici.carDistanceCounter <= 1500)
            {
                seviye[x].GetComponent<level_ic>().bas.transform.Rotate(new Vector3(0, 0, Random.Range(-11f, 13f)));
            }
            if (oyunici.carDistanceCounter >= 1500 && oyunici.carDistanceCounter <= 2000)
            {
                seviye[x].GetComponent<level_ic>().bas.transform.Rotate(new Vector3(0, 0, Random.Range(-14f, 18f)));
            }
            seviye[x].SetActive(true);
            /*         RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit))
                    {
                        if (hit.transform.gameObject.tag == "iboreis" || hit.transform.gameObject.layer == 17)
                        {
                            for (int i = 0; i < seviye.Count; i++)
                            {
                                if (hit.transform.root.GetChild(x).name != seviye[i].name && oyunici.flip == false)
                                {

                                    seviye[i].SetActive(false);
                                    Debug.Log("enes abi3");
                                }
                            }
                        } 
        }*/
    }
}
}


