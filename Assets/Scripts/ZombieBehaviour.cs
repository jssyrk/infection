using UnityEngine;
using System.Collections;

public class ZombieBehaviour : MonoBehaviour {

	private Transform player;
	public int health = 10;
	public int damage = 100;
	public GameObject explosionPrefab;
	public float adjustExplosionAngle = 0.0f;


	void Start(){
		if(GameObject.FindWithTag("Player")){
			player = GameObject.FindWithTag ("Player").transform;

			GetComponent<MoveTowardsObject>().target = player;
			GetComponent<SmoothLookAtTarget2D>().target = player;
		}
	}

	
	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.CompareTag("Player")){
			other.transform.SendMessage( "TakeDamage", damage );
				//player = GameObject.FindWithTag ("Player").transform;

			//	GetComponent<MoveTowardsObject>().target = player;
				//GetComponent<SmoothLookAtTarget2D>().target = player;
		}
	}



	public void TakeDamage(int damage){
		health -= damage;

		if(health <= 0){

			Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + adjustExplosionAngle);
			Instantiate(explosionPrefab, transform.position, newRot);
					
			GetComponent<AddScore>().DoSendScore();
			Destroy(gameObject);
		}
	}

	void FixedUpdate(){
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.angularVelocity = 0.0f;
	}

}
