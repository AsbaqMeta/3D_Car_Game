using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class isim_ac : MonoBehaviour {
	public string[] isimler;
	 
	public Text[] isimler_text_bat,isimler_text_vs;
	// Use this for initialization
	void Start () {
		int i = Random.Range (0, isimler.Length-4);

		isimler_text_vs[0].text=isimler [i];
		isimler_text_vs[1].text=isimler [i+1];

		isimler_text_bat[0].text=isimler [i];
		isimler_text_bat[1].text=isimler [i+1];
		isimler_text_bat[2].text=isimler [i+2];
		isimler_text_bat[3].text=isimler [i+3];

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
