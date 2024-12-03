using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraMenu : MonoBehaviour
{
    public GameObject[] cameraWaypoints;
    public GameObject spawnPos;
    public GameObject _stagePanel;

    public int cameraPositionIdicator;
    public float lerpSpeed;
    // Start is called before the first frame update
    void Start()
    {
          transform.position=cameraWaypoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {

      if(!_stagePanel.activeSelf)
      {
         if (Input.GetMouseButton(0))
        {
            transform.position = Vector3.Lerp(transform.position, cameraWaypoints[cameraPositionIdicator].transform.position, Time.smoothDeltaTime * (lerpSpeed + 0.07f));
            transform.LookAt(spawnPos.transform.position);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, cameraWaypoints[0].transform.position, Time.smoothDeltaTime * (lerpSpeed +0.3f));
            transform.LookAt(spawnPos.transform.position);
        }
      }
       

    }
}
