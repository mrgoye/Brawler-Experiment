using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour {

	public Transform target;
	public float distance;

	public static bool isGrounded;
	public static bool hasLanded;
	public static bool playerIsRight;
	public static float playerX;
	public static bool p1Punching = false;
	public static bool hasEnteredSS = false;	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		var z = target.position.z -distance;
		var y = target.position.y;
		var x = target.position.x;

		transform.position = new Vector3 (x, y, z);
	}
}
