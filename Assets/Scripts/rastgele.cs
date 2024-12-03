using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rastgele : MonoBehaviour {
    public GameObject[] point;
	// Use this for initialization
	void OnEnable () {
        int rand = Random.Range(0, point.Length);
        transform.position = point[3].transform.position;   	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
