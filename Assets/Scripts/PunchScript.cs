using UnityEngine;
using System.Collections;

public class PunchScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckPunch ();
	}

	void CheckPunch() {
		GlobalScript.p1Punching = false;
		if (Input.GetKeyDown (KeyCode.M)) {
			this.GetComponent<Animator>().SetTrigger("Punch");
			GlobalScript.p1Punching = true;
		}
	}
}
