using UnityEngine;
using System.Collections;

public class PlayGameButton : MonoBehaviour {

	public string levelName = "Zombie Shooter Level 1";


	void OnMouseUp(){
		Application.LoadLevel(levelName);
	}
}
