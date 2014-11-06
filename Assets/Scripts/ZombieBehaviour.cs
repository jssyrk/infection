using UnityEngine;
using System.Collections;

public class ZombieBehaviour : MonoBehaviour {

	private Transform player;
	public int health = 10;
	public int damage = 100;
	private int initialHealth;


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
		}
	}



	public void TakeDamage(int damage){
		health -= damage;

		if(health <= 0){
			GetComponent<AddScore>().DoSendScore();
			gameObject.SetActive(false);
			GetComponent<SpawnerObject>().Spawn ();
		}
	}

	void FixedUpdate(){
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.angularVelocity = 0.0f;
	}

	void Awake(){
		initialHealth = health;
	}

	void OnEnable(){
		health = initialHealth;
	}

}
