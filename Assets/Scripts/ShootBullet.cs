using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour {

	public SpawnerObject bulletSpawn;
	public float fireTime = 0.5f;

	private bool isFiring = false;

	void SetFiring(){
		isFiring = false;
	}

	void Fire(){
		isFiring = true;
		bulletSpawn.Spawn();

		if(audio){
			audio.Play();
		}

		Invoke ("SetFiring", fireTime);
	}

	void Update(){
		if (Input.GetMouseButton (0)) {
			if(!isFiring){
				Fire ();
			}		
		}
	}
}
