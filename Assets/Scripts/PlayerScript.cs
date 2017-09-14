using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public float jumpForce;

	private bool isRight = true;
	private bool isWalking = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckMovements ();
		CheckAnim ();
		GlobalScript.playerIsRight = this.isRight;
		GlobalScript.playerX = this.transform.position.x;
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
			this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
		}
	}

	void CheckAnim(){
		this.transform.GetComponent<Animator> ().SetBool ("isWalking", this.isWalking);
		this.transform.GetComponent<Animator> ().SetBool ("isPunching", GlobalScript.p1Punching);
		this.transform.GetComponent<Animator> ().SetBool ("isJumping", !GlobalScript.isGrounded);
	}
}
