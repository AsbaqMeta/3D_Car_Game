using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class gradientKontrol : MonoBehaviour {
	
	// Use this for initialization
	void OnEnable () 
	{
		transform.localPosition = new Vector3 (transform.localPosition.x,transform.localPosition.y+Screen.height*2f,transform.localPosition.z);
//		lerpedcolor=Color32.Lerp(ColorWhite,ColorBlack,Time.deltaTime*50);
//
//		transform.GetComponent<Image>().color=lerpedcolor;
	}

	// Update is called once per frame
	public float speed;

	//public Mesh egemen;
	//public Color col;
	void Update () {
		//transform.GetComponent<Gradient> ().ModifyMesh (egemen);

		transform.localPosition = Vector3.MoveTowards (transform.localPosition,Vector3.zero,Time.deltaTime*speed);
	}
}
