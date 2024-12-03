using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_yapici_vs : MonoBehaviour
{
    public GameObject level;

    [System.Serializable]
    public struct yapi
    {
        public int[] Tur1;
    }
    public yapi[] tur;

    public GameObject finish;
    public Transform[] trees;
    GameObject canvas;

    // Use this for initialization
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 4|| SceneManager.GetActiveScene().buildIndex == 3)
        {
            for (int i = 0; i < trees.Length; i++)
            {
                if (i != 0)
                {
                    trees[i].gameObject.SetActive(false);
                }

            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 1|| SceneManager.GetActiveScene().buildIndex == 4|| SceneManager.GetActiveScene().buildIndex == 3)
        {
            trees[canvas.GetComponent<oyunici>().TreeIndex].gameObject.SetActive(true);

        }


        if (PlayerPrefs.GetInt("Oyun_modu") == 1 || PlayerPrefs.GetInt("Oyun_modu") == 2 || (PlayerPrefs.GetInt("Oyun_modu") == 6 && PlayerPrefs.GetInt("Tur") == 2))
        {
            level = GameObject.FindGameObjectWithTag("level");
            for (int i = 0; i < level.transform.childCount; i++)
            {
                //level.transform.GetChild(i).GetComponent<spawner_ac>().enabled = false;
                level.transform.GetChild(i).GetComponent<spawner_ac>().spawner.SetActive(false);
            }
            int deger = Random.Range(0, tur.Length);

            int deger2 = Random.Range(0, tur[deger].Tur1.Length);

            level.transform.GetChild(tur[deger].Tur1[0]).GetComponent<level_ic>().bas.transform.position = GetComponent<level_ic>().son.transform.position;
            level.transform.GetChild(tur[deger].Tur1[0]).GetComponent<level_ic>().bas.transform.Rotate(new Vector3(0, 0, Random.Range(2, 7)));
            /*   if (SceneManager.GetActiveScene().buildIndex == 1)
              {
                  level.transform.GetChild(tur[deger].Tur1[0]).GetComponent<spawner_ac>().BridgeWays.gameObject.SetActive(false);
              } */
            level.transform.GetChild(tur[deger].Tur1[0]).gameObject.SetActive(true);
            for (int i = 1; i < tur[deger].Tur1.Length; i++)
            {
                level.transform.GetChild(tur[deger].Tur1[i]).GetComponent<level_ic>().bas.transform.position = level.transform.GetChild(tur[deger].Tur1[i - 1]).GetComponent<level_ic>().son.transform.position;
                level.transform.GetChild(tur[deger].Tur1[i]).gameObject.SetActive(true);
            }

            finish.transform.GetComponent<level_ic>().bas.transform.position = level.transform.GetChild(tur[deger].Tur1[tur[deger].Tur1.Length - 1]).GetComponent<level_ic>().son.transform.position;
            finish.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
