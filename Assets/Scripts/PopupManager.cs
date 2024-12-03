using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PopupManager : MonoBehaviour
{
    public static PopupManager m_instance;
    public bool m_isRewarded = false;
    public GameObject m_LoadingPopup;
    public GameObject m_Completed;
    public GameObject m_Failed;
    public float m_WaitLoad;
    public Text m_GainedText;
    public void DestroyPopup()
    {
        if(m_isRewarded) m_instance = null;
        Destroy(gameObject);
    }

    public void DestroyGoScene(string scene)
    {
        StartCoroutine(LoadScene(scene));
    }

    private void Start()
    {
        if (m_isRewarded)
        {
            if (m_instance == null)
            {
                m_instance = this;
            }
            else if(m_instance!= this)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator LoadScene(string scene)
    {
        //Loading Popup burda yüklenecek
        Instantiate(m_LoadingPopup, GameObject.Find("Canvas").GetComponent<RectTransform>(), worldPositionStays: false);
        m_WaitLoad = Random.Range(2.5f, 5f);
        yield return new WaitForSeconds(m_WaitLoad);
        SceneManager.LoadScene(scene);
        Destroy(gameObject);
    }
}
