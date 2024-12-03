using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SwipeMenu : MonoBehaviour
{
    public GameObject scrollBar;
    public GameObject map;
    private float scroll_pos = 0;
    private float[] pos;
    public GameObject LoadingPanel ;
    public static int stageIndex;
    bool touch;
    // Start is called before the first frame update
    void Start()
    {
        touch = false;
       
    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {
        map.transform.position =Vector3.Lerp(map.transform.position,new Vector3(8*scroll_pos,map.transform.position.y,map.transform.position.z) ,Time.deltaTime);
        pos = new float[transform.childCount];
        float scrollDistance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = scrollDistance * i;
        }
        if (Input.GetMouseButton(0) && !LoadingPanel.activeSelf)
        {
            scroll_pos = scrollBar.GetComponent<Scrollbar>().value;
            touch = true;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (!touch)
                {
                    if (scroll_pos < pos[i] + (scrollDistance / 2) && scroll_pos > pos[i] - (scrollDistance / 2))
                    {
                        scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, pos[PlayerPrefs.GetInt("SaveMap")], 0.25f);
                        stageIndex = i;
                        scroll_pos = scrollBar.GetComponent<Scrollbar>().value;
                    }
                }
                if (touch)
                {
                    if (scroll_pos < pos[i] + (scrollDistance / 2) && scroll_pos > pos[i] - (scrollDistance / 2))
                    {
                        scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, pos[i], 2f * Time.fixedDeltaTime);
                        stageIndex = i;
                        scroll_pos = scrollBar.GetComponent<Scrollbar>().value;
                    }
                }
            }
        }
        for (int i = 0; i < pos.Length; i++)
        {

            if (scroll_pos < pos[i] + (scrollDistance / 2) && scroll_pos > pos[i] - (scrollDistance / 2))
            {
                if (!touch)
                {
                    transform.GetChild(PlayerPrefs.GetInt("SaveMap")).localScale = Vector2.Lerp(transform.GetChild(PlayerPrefs.GetInt("SaveMap")).localScale, new Vector2(1.5f, 1.5f), 0.15f);
                }

                if (touch)
                {
                    transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1.5f, 1.5f), 0.15f);//i olan butonu büyüt
                }

                for (int a = 0; a < pos.Length; a++)
                {
                    if (a != i)
                    {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(1f, 1f), 0.15f);
                    }
                }
            }
        }
    }

}
