using UnityEngine;
using System.Collections;

public class GroundedScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.layer == 8)
			GlobalScript.isGrounded = true;
			this.gameObject.name = "GROUNDED";
	}

	void OnTriggerExit2D(Collider2D col) {
		if(col.gameObject.layer == 8)
			GlobalScript.isGrounded = false;
			this.gameObject.name = "NOT_GROUNDED";
	}
}
