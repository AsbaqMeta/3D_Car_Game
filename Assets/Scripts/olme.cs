using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class olme : MonoBehaviour {
	public GameObject karakter_kod;
	public AudioClip[] _neckCracedSound;
	// Use this for initialization
	void Start ()
	{
		Canvass=GameObject.Find ("Canvas");
	}
	
	// Update is called once per frame
	void Update ()
	{
        if(Canvass.GetComponent<oyunici>().olme)
		{
			gameObject.GetComponent<BoxCollider>().enabled = false;
		}
		if (!Canvass.GetComponent<oyunici>().olme)
		{
			gameObject.GetComponent<BoxCollider>().enabled = true;
		}
	}
	public GameObject Canvass;

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 10  || other.gameObject.layer == 17 || other.gameObject.layer == 13)
		{
			Canvass.GetComponent<oyunici> ().olme = true;
		 	karakter_kod.GetComponent<adam_oldu> ().dead = true;
            transform.GetComponent<AudioSource>().enabled = true;
			transform.GetComponent<AudioSource>().PlayOneShot(_neckCracedSound[Random.Range(0,_neckCracedSound.Length)]);
        }
	}
}
