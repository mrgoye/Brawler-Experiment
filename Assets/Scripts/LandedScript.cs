using UnityEngine;
using System.Collections;

public class LandedScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.layer == 8) {
			GlobalScript.hasLanded = true;
			this.gameObject.name = "LANDED";
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if(col.gameObject.layer == 8)
			GlobalScript.hasLanded = false;
		this.gameObject.name = "NOT_LANDED";
	}
}
