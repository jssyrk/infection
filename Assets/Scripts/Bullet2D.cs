using UnityEngine;
using System.Collections;

public class Bullet2D : MonoBehaviour {

	public float speed = 10.0f;
	public float destroyTime = 2.0f;

	void OnEnable(){
		Invoke ("Die", destroyTime);
	}

	void Die(){
		gameObject.SetActive (false);
	}

	void OnDisable(){
		CancelInvoke ("Die");
	}

	void FixedUpdate(){
		rigidbody2D.velocity = transform.up * speed;
	}
}
