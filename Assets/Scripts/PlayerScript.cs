using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public float jumpForce;

	private bool isRight = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckMovements ();
		GlobalScript.playerIsRight = this.isRight;
		GlobalScript.playerX = this.transform.position.x;
	}

	void CheckMovements(){
		if (Input.GetKey (KeyCode.Q)) {
			if(this.isRight)
				this.transform.Rotate(new Vector3(0,180,0));
			this.transform.Translate (Vector2.right * speed);
			this.isRight = false;
		} else if (Input.GetKey (KeyCode.D)) {
			if(!this.isRight)
				this.transform.Rotate(new Vector3(0,180,0));
			this.transform.Translate (Vector2.right * speed);
			this.isRight = true;
		} else if (Input.GetKeyDown (KeyCode.Z) && GlobalScript.isGrounded) {
			this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
		}
	}
}
