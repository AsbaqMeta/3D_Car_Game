using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adam_oldu : MonoBehaviour
{
	public GameObject canvas;
	public GameObject adam_son;
	public GameObject adam2,adam3;
	public bool oldu2,firlat;
	public bool dead;
	public GameObject partileeeee;
	// Use this for initialization
	void Start () 
	{
		canvas = GameObject.Find("Canvas");

		//oldu = false;
		oldu2 = false;
		dead = false;
		firlat = false;
       if (transform.tag != "karakter_Arac")
		{
           int ras = Random.Range(0,transform.GetChild(0).childCount - 1);
           transform.GetChild(0).GetChild(ras).gameObject.SetActive(true);
       }
	}
	void Update ()
	{
		if (dead)
		{
			partileeeee.GetComponent<ParticleSystem>().Play();

			adam_son.gameObject.SetActive(false);
			
            adam2.transform.parent = null;
            adam2.SetActive (true);
			
			dead = false;
		}
        if (canvas.GetComponent<oyunici>().olme == false && adam2.transform.parent == null)
        {
            adam2.transform.parent = this.gameObject.transform;
            adam2.transform.position = adam_son.transform.position;
			adam2.transform.rotation = adam_son.transform.rotation;
			adam2.transform.Find("root").transform.position = adam_son.transform.Find("root").transform.position;
			adam2.transform.Find("root").transform.rotation = adam_son.transform.Find("root").transform.rotation;
		}
     
    }
	
	
}
