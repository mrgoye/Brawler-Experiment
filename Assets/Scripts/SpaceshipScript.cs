using UnityEngine;
using System.Collections;

public class SpaceshipScript : MonoBehaviour {

	public float maxGravDist = 4.0f;
	public float maxGravity = 35.0f;

	public float propForce;
	public float rotationSpeed;

	private GameObject[] planets;
	private Vector3 dir;

	// Use this for initialization
	void Start () {
		planets = GameObject.FindGameObjectsWithTag("Planet");
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalScript.hasLanded) {
			this.GetComponent<Rigidbody2D>().freezeRotation = true;
		}
		if (GlobalScript.hasEnteredSS) {
			CheckCommands();
		}
	}

	void FixedUpdate () {
		foreach(var planet in planets) {
			var dist = Vector3.Distance(planet.transform.position, transform.position);
			if (dist <= maxGravDist) {
				var v = planet.transform.position - transform.position;
				dir = v;
				var rigidbody2D = this.transform.GetComponent<Rigidbody2D>();
				rigidbody2D.AddForce(v.normalized * (1.0f - dist / maxGravDist) * maxGravity);
			}
		}
	}

	void CheckCommands(){
		if (Input.GetKey (KeyCode.Z)) {
			if(GlobalScript.hasLanded)
				this.GetComponent<Rigidbody2D>().AddForce(-dir * propForce);
			else {
				var tail = GameObject.FindGameObjectWithTag("SSTail");
				dir = tail.transform.position - transform.position;
				this.GetComponent<Rigidbody2D>().AddForce(-dir * propForce);
			}
		}
		if (Input.GetKey (KeyCode.D) && !GlobalScript.hasLanded) {
			this.transform.Rotate(new Vector3(0, 0, 1) * -rotationSpeed);
		}
		if (Input.GetKey (KeyCode.Q) && !GlobalScript.hasLanded) {
			this.transform.Rotate(new Vector3(0, 0, 1) * rotationSpeed);
		}
		if (Input.GetKey (KeyCode.S) && !GlobalScript.hasLanded) {
			this.GetComponent<Rigidbody2D>().AddForce(dir * propForce);
		}
	}

}
