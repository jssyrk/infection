using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public delegate void UpdateHealth (int newHealth);
	public static event UpdateHealth onUpdateHealth;

	public int health = 100;
	public Transform walkingTransform;

	public string deathScreen = "Death Screen";

	private int score;
	private Animator anim;
	private Animator walkingAnim;
	private AudioSource walkingSound;

	void Start(){

		anim = GetComponent<Animator> ();
		walkingAnim = walkingTransform.GetComponent<Animator> ();
		walkingSound = walkingTransform.GetComponent<AudioSource> ();


		if(onUpdateHealth != null){
			onUpdateHealth(health);
		}
	}

	void Update(){

		if(Input.GetMouseButton(0)){
			anim.SetBool("isFiring", true);
		}
		else{
			anim.SetBool("isFiring", false);
		}

		if(rigidbody2D.velocity != Vector2.zero){
			walkingAnim.SetBool("isWalking", true);

			if(!walkingSound.isPlaying){
				walkingSound.Play ();
				walkingSound.loop = true;
			}
		}
		else{

			walkingAnim.SetBool("isWalking", false);

			if(walkingSound.isPlaying){

				walkingSound.Stop ();
				walkingSound.loop = false;
			}
		}
	}

	public void TakeDamage(int damage){



		health -= damage;

		if(onUpdateHealth != null){
			onUpdateHealth(health);
		}

		if(health <=0){
			Die();

			Application.LoadLevel(deathScreen);

		}
	}

	void Die(){

	}
}
