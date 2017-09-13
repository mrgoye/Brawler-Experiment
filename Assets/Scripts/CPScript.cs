using UnityEngine;
using System.Collections;

public class CPScript : MonoBehaviour {

	public float chasingDistance;
	public float chasingSpeed;

	private float damages = 0;
	private bool isLeft = true; 
	private Vector2 previousVel;
	private bool isUnderForce = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (damages + "%");
		CheckAI ();
	}

	void FixedUpdate() {
		var vel = this.transform.GetComponent<Rigidbody2D>().velocity;
		if (vel != Vector2.zero)
			this.isUnderForce = true;
		else
			this.isUnderForce = false;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.layer == 9) {
			TakeDamages();
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.layer == 10) {
			CheckRecoilFromHit();
		}
	}

	void TakeDamages(){
		this.damages += 10;
	}

	void CheckRecoilFromHit(){
		var direction = GlobalScript.playerIsRight ? 1 : -1;
		this.GetComponent<Rigidbody2D>().AddForce(direction * Vector2.right * (damages * 2));
		previousVel = this.transform.GetComponent<Rigidbody2D> ().velocity;
	}

	void CheckAI(){
		if (!this.isUnderForce) {
			//Chase
			if (GlobalScript.playerX > this.transform.position.x && !this.isLeft) { //Player is on the right
				this.isLeft = true;
				this.transform.Rotate (new Vector3 (0, 180, 0));
			} else if (GlobalScript.playerX < this.transform.position.x && this.isLeft) { //Player is on the left
				this.isLeft = false;
				this.transform.Rotate (new Vector3 (0, 180, 0));
			}
			if (Mathf.Abs (this.transform.position.x - GlobalScript.playerX) > chasingDistance)
				this.transform.Translate (Vector2.right * chasingSpeed);
		}
	}
}
