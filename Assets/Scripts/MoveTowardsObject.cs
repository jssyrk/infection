using UnityEngine;
using System.Collections;

public class MoveTowardsObject : MonoBehaviour {

	public Transform target;
	public float speed = 5.0f;

	void FixedUpdate(){
		if (target != null) {

			if(rigidbody2D != null){
				rigidbody2D.velocity = Vector2.zero;
				rigidbody2D.angularVelocity = 0.0f;
			}

			transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 0.01f);
		}
	}
}
