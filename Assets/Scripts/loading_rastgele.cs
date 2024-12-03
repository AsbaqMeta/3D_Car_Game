using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loading_rastgele : MonoBehaviour {
    public GameObject[] loading_panel;
	// Use this for initialization
	void OnEnable () {
        int deger = Random.Range(0, loading_panel.Length);
        loading_panel[deger].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
