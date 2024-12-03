using UnityEngine;
using System.Collections;

public class bitis : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	public Transform AsilOyuncu;
	public Transform Kaybettin;
	public bool once=true;
	void OnCollisionEnter(Collision coll)
	{
		if(once)
		if (coll.gameObject.layer == 9 || coll.gameObject.layer == 10) 
		{			
//			AsilOyuncu.GetComponent<CokOyuncuHaraket> ().AsagiDustum (0,Camera.main.GetComponent<sahne_ayarlar>().oyun_zaman,0);
	//		AsilOyuncu.GetComponent<CokOyuncuHaraket> ().AsagiDustumBool = true;
			Kaybettin.gameObject.SetActive (true);

		}
	}
}
