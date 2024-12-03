using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    GameObject canvas;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
       //Vector3 fwd = Vector3.down;
       //        RaycastHit hit;
       // if (Physics.Raycast(transform.position, fwd, out hit, 10))
       // {


       //     if (Vector3.Distance(transform.position, hit.point) > 2f)
       //     {
       //         canvas.GetComponent<oyunici>().player.GetComponent<truckk_yeni>().carflying = true;
       //     }


       //     if (Vector3.Distance(transform.position, hit.point) <= 2f)
       //     {
       //         canvas.GetComponent<oyunici>().player.GetComponent<truckk_yeni>().carflying = false;
       //     }
       //     if (Vector3.Distance(transform.position, hit.point) > 0.3f)
       //     {
       //         canvas.GetComponent<oyunici>().player.GetComponent<truckk_yeni>().carflying2 = true;
       //     }


       //     if (Vector3.Distance(transform.position, hit.point) <= 0.3f)
       //     {
       //         canvas.GetComponent<oyunici>().player.GetComponent<truckk_yeni>().carflying2 = false;
       //     }

       // }
       
    }
}
