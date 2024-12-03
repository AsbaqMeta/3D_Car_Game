using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
    public GameObject _carFolowCollider;
	public GameObject araba;
	private GameObject Canvas;
    bool once=false;
    public GameObject _backWallCollider;
    // Use this for initialization
    void OnEnable ()
     	{

        gameObject.SetActive(true);
        _backWallCollider.SetActive(false);
        once = true;
        }
    private void Start()
    {
        Canvas = GameObject.Find("Canvas");
        _carFolowCollider = GameObject.Find("CarFollowCollider");
    }
    // Update is called once per frame
    void Update () {
        //if (this.gameObject.activeSelf)
        //{
            
        //}
  //      if (!araba) 
		//{
		//	araba = Canvas.GetComponent<oyunici> ().player;
		//}
	}
	void OnTriggerEnter(Collider other) 
	{
        if(once)
        {
            if (other.gameObject.layer == 8 && PlayerPrefs.GetInt("Oyun_modu") == 0)
            {
                //araba.transform.GetChild(0).GetChild(0).GetComponent<level_yapici>().spawn();
                _carFolowCollider.GetComponent<level_yapici>().spawn();


                _backWallCollider.SetActive(true);
                this.gameObject.SetActive(false);
                once = false;   
            }

            if (other.gameObject.layer == 8 && PlayerPrefs.GetInt("Oyun_modu") == 6 )
            {
               // araba.transform.GetChild(0).GetChild(0).GetComponent<level_yapici>().spawn();
                _carFolowCollider.GetComponent<level_yapici>().spawn();
                this.gameObject.SetActive(false);
                once = false;
            }
        }
       
    }
}
