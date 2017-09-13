using UnityEngine;
using System.Collections;

public class ComboScript : MonoBehaviour {

	public float comboTimeInterval;

	private bool comboStarted = false;
	private float fullTime;

	// Use this for initialization
	void Start () {
		fullTime = comboTimeInterval;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("time since combo started : " + comboTimeInterval);
		if (comboTimeInterval == fullTime)
			InitiateCombo ();
		if (comboStarted) {
			comboTimeInterval -= Time.deltaTime;
		}
		if (comboTimeInterval < 0) {
			comboStarted = false;
			comboTimeInterval = fullTime;
			this.transform.Translate(new Vector2(-1.5f, 0));
		}
	}

	void InitiateCombo(){
		if (Input.GetKeyDown (KeyCode.M)) {
			this.transform.Translate(new Vector2(1.5f,0));
			comboStarted = true;
		}
	}
}
