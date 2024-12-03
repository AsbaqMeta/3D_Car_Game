using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class loading : MonoBehaviour
{

    public Transform[] objeler;

    public Image empty, full;
    public Text teext;
    IEnumerator load(int scene)
    {
        yield return null;
        PlayerPrefs.SetInt("Sahne", scene);
        AsyncOperation ao = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        ao.allowSceneActivation = false;
        float progress = 0;
        while (!ao.isDone)
        {
            progress = Mathf.Clamp01(ao.progress / 0.9f);
            //progress = Mathf.MoveTowards (progress,397,Time.deltaTime*5f);
            full.rectTransform.sizeDelta = new Vector3(progress * 100, full.rectTransform.sizeDelta.y, 0);
            teext.text = (int)(progress * 100) + "%";
            if (ao.progress == 0.9f)
            {

                ao.allowSceneActivation = true;
            }

            yield return null;
        }


    }

    void Start()
    {
        if (PlayerPrefs.GetInt("oyun_modu") == 1)
        {

            if (PlayerPrefs.GetInt("Seviye") == 1)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(2));

            }
            if (PlayerPrefs.GetInt("Seviye") == 2)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(2));
            }
            if (PlayerPrefs.GetInt("Seviye") == 3)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(2));

            }
            if (PlayerPrefs.GetInt("Seviye") == 4)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(2));

            }
            if (PlayerPrefs.GetInt("Seviye") == 5)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(2));
            }
            if (PlayerPrefs.GetInt("Seviye") == 6)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(2));

            }
            if (PlayerPrefs.GetInt("Seviye") == 7)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(2));

            }
            if (PlayerPrefs.GetInt("Seviye") == 8)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(2));

            }
            if (PlayerPrefs.GetInt("Seviye") == 9)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(2));

            }
            if (PlayerPrefs.GetInt("Seviye") == 10)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(2));

            }
            if (PlayerPrefs.GetInt("Seviye") == 11)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(2));

            }
            if (PlayerPrefs.GetInt("Seviye") == 12)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(2));

            }
            if (PlayerPrefs.GetInt("Seviye") == 13)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(5));

            }
            if (PlayerPrefs.GetInt("Seviye") == 14)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(8));

            }
            if (PlayerPrefs.GetInt("Seviye") == 15)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(7));

            }
            if (PlayerPrefs.GetInt("Seviye") == 16)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(3));
            }
            if (PlayerPrefs.GetInt("Seviye") == 17)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(4));
            }
            if (PlayerPrefs.GetInt("Seviye") == 18)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(8));
            }
            if (PlayerPrefs.GetInt("Seviye") == 19)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(9));

            }
            if (PlayerPrefs.GetInt("Seviye") == 20)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(9));

            }
            if (PlayerPrefs.GetInt("Seviye") == 21)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(3));
            }
            if (PlayerPrefs.GetInt("Seviye") == 22)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(2));
            }
            if (PlayerPrefs.GetInt("Seviye") == 23)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(5));
            }
            if (PlayerPrefs.GetInt("Seviye") == 24)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(8));
            }
            if (PlayerPrefs.GetInt("Seviye") == 25)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(7));
            }
            if (PlayerPrefs.GetInt("Seviye") == 26)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(4));
            }
            if (PlayerPrefs.GetInt("Seviye") == 27)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(8));
            }
            if (PlayerPrefs.GetInt("Seviye") == 28)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(6));
            }
            if (PlayerPrefs.GetInt("Seviye") == 29)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(7));
            }
            if (PlayerPrefs.GetInt("Seviye") == 30)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(4));
            }
            if (PlayerPrefs.GetInt("Seviye") == 31)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(7));

            }
            if (PlayerPrefs.GetInt("Seviye") == 32)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(8));

            }
            if (PlayerPrefs.GetInt("Seviye") == 33)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(6));
            }
            if (PlayerPrefs.GetInt("Seviye") == 34)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(9));

            }
            if (PlayerPrefs.GetInt("Seviye") == 35)
            {
                PlayerPrefs.SetInt("oyun_modu", 2);
                StartCoroutine(load(3));
            }
        }
        if (PlayerPrefs.GetInt("oyun_modu") == 3)
        {
            PlayerPrefs.SetInt("oyun_modu", 4);
            StartCoroutine(load(2));
        }
        if (PlayerPrefs.GetInt("oyun_modu") == 5)
        {
            PlayerPrefs.SetInt("oyun_modu", 6);
            StartCoroutine(load(2));
        }

        if (PlayerPrefs.GetInt("oyun_modu") == 7)
        {
            PlayerPrefs.SetInt("oyun_modu", 8);
            StartCoroutine(load(2));
        }
    }
}