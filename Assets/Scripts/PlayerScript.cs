using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public float jumpForce;
	public float maxGravDist = 4.0f;
	public float maxGravity = 35.0f;

	private bool isRight = true;
	private bool isWalking = false;
	private Vector3 attractionDir;

	private GameObject[] planets;
	
	// Use this for initialization
	void Start () {
		planets = GameObject.FindGameObjectsWithTag("Planet");
		Debug.Log ("found " + planets.Length + "planet(s)");
	}
	
	// Update is called once per frame
	void Update () {
		if (!GlobalScript.hasEnteredSS) {
			CheckMovements ();
			CheckAnim ();
			GlobalScript.playerIsRight = this.isRight;
			GlobalScript.playerX = this.transform.position.x;
			if (this.isWalking || !GlobalScript.isGrounded)
				this.transform.GetComponent<Rigidbody2D> ().freezeRotation = false;
			else
				this.transform.GetComponent<Rigidbody2D> ().freezeRotation = true;
		} else {
			this.GetComponent<BoxCollider2D>().enabled = false;
			this.GetComponent<Animator>().enabled = false;
			this.GetComponent<SpriteRenderer>().enabled = false;
			var ss = GameObject.FindGameObjectWithTag("Spaceship");
			this.transform.parent = ss.transform;
			this.transform.position = this.transform.parent.position;
		}
	}

	void FixedUpdate () {
		foreach(var planet in planets) {
			var dist = Vector3.Distance(planet.transform.position, transform.position);
			if (dist <= maxGravDist) {
				var v = planet.transform.position - transform.position;
				this.attractionDir = v;
				var rigidbody2D = this.transform.GetComponent<Rigidbody2D>();
				rigidbody2D.AddForce(v.normalized * (1.0f - dist / maxGravDist) * maxGravity);
			}
		}
	}

	void CheckMovements(){
		this.isWalking = false;
		if (Input.GetKey (KeyCode.Q)) {
			this.isWalking = true;
			if(this.isRight)
				this.transform.Rotate(new Vector3(0,180,0));
			this.transform.Translate (Vector2.right * speed);
			this.isRight = false;
		} else if (Input.GetKey (KeyCode.D)) {
			this.isWalking = true;
			if(!this.isRight)
				this.transform.Rotate(new Vector3(0,180,0));
			this.transform.Translate (Vector2.right * speed);
			this.isRight = true;
		} else if (Input.GetKeyDown (KeyCode.Z) && GlobalScript.isGrounded) {
			this.GetComponent<Rigidbody2D> ().AddForce (-this.attractionDir * jumpForce);
		}
	}

	void CheckAnim(){
		this.transform.GetComponent<Animator> ().SetBool ("isWalking", this.isWalking);
		this.transform.GetComponent<Animator> ().SetBool ("isPunching", GlobalScript.p1Punching);
		this.transform.GetComponent<Animator> ().SetBool ("isJumping", !GlobalScript.isGrounded);
	}		
}
