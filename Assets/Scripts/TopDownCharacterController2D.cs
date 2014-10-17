using UnityEngine;
using System.Collections;
	
	[RequireComponent (typeof(Rigidbody2D))]
public class TopDownCharacterController2D : MonoBehaviour {

	public float speed = 5.0f;

	void FixedUpdate(){
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		rigidbody2D.velocity = new Vector2 (x, y) * speed;
		rigidbody2D.angularVelocity = 0.0f;
	}
}
