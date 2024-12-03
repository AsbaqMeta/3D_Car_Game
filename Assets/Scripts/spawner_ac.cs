using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class spawner_ac : MonoBehaviour
{
    public GameObject[] _boxesSpawner;
    public GameObject[] _billetSpawner;
    public Transform[] trees;
    public GameObject _ramps;
    public Transform BridgeWays;
    public GameObject _destroyedObject;
    public GameObject _boxSpawnDot, _billetSpawnDot;
    public GameObject spawner;
    public Transform _coins;
    GameObject canvas;
    private GameObject[] battleWay;

   
    void OnEnable()
    {
        battleWay = GameObject.FindGameObjectsWithTag("2ndWays");
        for (int i = 0; i < battleWay.Length; i++)
        {
            if (PlayerPrefs.GetInt("Oyun_modu") == 2 || PlayerPrefs.GetInt("Oyun_modu") == 1 || (PlayerPrefs.GetInt("Oyun_modu") == 6 && PlayerPrefs.GetInt("Tur") == 2))
            {
                battleWay[i].SetActive(true);
            }
            else
            {
                battleWay[i].SetActive(false);
            }
        }
        canvas = GameObject.Find("Canvas");
        if ((PlayerPrefs.GetInt("Oyun_modu") == 0 || (PlayerPrefs.GetInt("Oyun_modu") == 6 && PlayerPrefs.GetInt("Tur") != 2)))
        {
            spawner.SetActive(true);

        }
        _coins.gameObject.SetActive(false);
        transform.Find("bas/Gems").gameObject.SetActive(false);
        for (int i = 0; i < _coins.childCount; i++)
        {
            _coins.transform.GetChild(i).gameObject.SetActive(false);
        }
        if (_ramps)
        {
            _ramps.SetActive(false);
        }
        if (BridgeWays)
        {
            BridgeWays.gameObject.SetActive(false);
        }



        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            for (int i = 0; i < trees.Length; i++)
            {
                if (i != 0)
                {
                    trees[i].gameObject.SetActive(false);
                }
            }
            trees[canvas.GetComponent<oyunici>().TreeIndex].gameObject.SetActive(true);
        }
        if ((PlayerPrefs.GetInt("Oyun_modu") == 6 && PlayerPrefs.GetInt("Tur") != 2))
        {
            if (transform.GetChild(0).transform.eulerAngles.z < 8)
            {
                float a = Random.Range(0, 2);
                if (a == 1 && _ramps)
                {
                    _ramps.gameObject.SetActive(true);
                }
                if (a == 0 && BridgeWays)
                {
                    BridgeWays.gameObject.SetActive(true);
                }
            }
        }
        if (PlayerPrefs.GetInt("Oyun_modu") == 0)
        {
            _coins.gameObject.SetActive(true);


           
                float a = Random.Range(0, 2);
                if (a == 1 && _ramps)
                {
                    _ramps.gameObject.SetActive(true);
                }
                if (a == 0 && BridgeWays)
                {
                    BridgeWays.gameObject.SetActive(true);
                }
            
            if (_boxSpawnDot)
            {
                GameObject.Instantiate(_boxesSpawner[Random.Range(0, _boxesSpawner.Length)], _boxSpawnDot.transform.position, Quaternion.identity, transform.Find("bas/DestroyedObject"));
            }
            if (oyunici.carDistanceCounter > 850 && _billetSpawnDot)
            {
                GameObject.Instantiate(_billetSpawner[Random.Range(0, _billetSpawner.Length)], _billetSpawnDot.transform.position, Quaternion.identity, transform.Find("bas/DestroyedObject"));
            }
        }

        if (PlayerPrefs.GetInt("Oyun_modu") == 6)
        {
            if (PlayerPrefs.GetInt("Tur") == 5)
            {
                transform.Find("bas/Gems").gameObject.SetActive(true);
            }
            if (PlayerPrefs.GetInt("Tur") == 1)
            {
                _coins.gameObject.SetActive(true);
            }
        }
        if (_coins.gameObject.activeSelf && oyunici.carDistanceCounter <= 300)
        {
            _coins.GetChild(0).gameObject.SetActive(true);

            for (int i = 0; i < _coins.transform.GetChild(0).childCount; i++)
            {
                _coins.transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
            }
        }
        if (_coins.gameObject.activeSelf && oyunici.carDistanceCounter <= 500 && oyunici.carDistanceCounter >= 300)
        {
            _coins.GetChild(1).gameObject.SetActive(true);
            for (int i = 0; i < _coins.GetChild(1).childCount; i++)
            {
                _coins.transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
            }
        }
        if (_coins.gameObject.activeSelf && oyunici.carDistanceCounter >= 500)
        {
            _coins.GetChild(2).gameObject.SetActive(true);
            for (int i = 0; i < _coins.GetChild(2).childCount; i++)
            {
                _coins.transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
            }
        }
        if ((PlayerPrefs.GetInt("Oyun_modu") == 0 || (PlayerPrefs.GetInt("Oyun_modu") == 6 && PlayerPrefs.GetInt("Tur") != 2)))
        {
            spawner.SetActive(true);

        }
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4)
        {
            for (int a = 0; a < trees[canvas.GetComponent<oyunici>().TreeIndex].transform.childCount; a++)
            {
                trees[canvas.GetComponent<oyunici>().TreeIndex].GetChild(a).transform.rotation = Quaternion.Euler(0, 0, transform.Find("bas").gameObject.transform.rotation.z);
            }
        }
    }
}
