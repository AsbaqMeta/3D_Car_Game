using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MissionSwipeMenu : MonoBehaviour
{
    public GameObject scrollBar;
    private float scroll_pos = 0;
    public GameObject map;

    private float[] pos;
    private int deneme1234;
    public static int MissionstageIndex;
    public static bool missioncounter;
    public GameObject LoadingPanel ;
    bool mission;

    // Start is called before the first frame update
    void Start()
    {
        mission = false;

    }

    public void MissionDegis()
    {
        mission = false;
    }

    // Update is called once per frame
    void Update()
    {
        map.transform.position = Vector3.Lerp(map.transform.position, new Vector3(8 * scroll_pos, map.transform.position.y, map.transform.position.z), Time.deltaTime);

        //Debug.Log(scroll_pos = scrollBar.GetComponent<Scrollbar>().value);
        pos = new float[transform.childCount];
        float scrollDistance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = scrollDistance * i;
        }
        if (Input.GetMouseButton(0) && !LoadingPanel.activeSelf)
        {
            scroll_pos = scrollBar.GetComponent<Scrollbar>().value;
            mission = true;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (scrollDistance / 2) && scroll_pos > pos[i] - (scrollDistance / 2))
                {
                    if (!mission)
                    {
                        scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, pos[PlayerPrefs.GetInt("Completed_mission")], 0.25f);
                        MissionstageIndex = i;
                        scroll_pos = scrollBar.GetComponent<Scrollbar>().value;
                    }
                    if (mission)
                    {
                        scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, pos[i], 0.25f);
                        MissionstageIndex = i;
                        scroll_pos = scrollBar.GetComponent<Scrollbar>().value;
                    }
                }
            }
        }
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (scrollDistance / 2) && scroll_pos > pos[i] - (scrollDistance / 2))
            {
                if (!mission)
                {
                    transform.GetChild(PlayerPrefs.GetInt("Completed_mission")).localScale = Vector2.Lerp(transform.GetChild(PlayerPrefs.GetInt("Completed_mission")).localScale, new Vector2(1.2f, 1.2f), 0.15f);
                }
                if (mission)
                {
                    transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.15f);
                }

                for (int a = 0; a < pos.Length; a++)
                    if (a != i)
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.15f);
            }
        }
    }

}
