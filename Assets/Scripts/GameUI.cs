using UnityEngine;
using System.Collections;

public class GameUI : MonoBehaviour {

	private int health;
	private int score;
	private string gameInfo = "";
	private double time;

	private Rect boxRect = new Rect(10,10,300,50);

	void OnEnable(){
		PlayerBehaviour.onUpdateHealth += HandleOnUpdateHealth;
		AddScore.onSendScore += OnSendScore;
	}

	void OnDisplay(){
		PlayerBehaviour.onUpdateHealth -= HandleOnUpdateHealth;
		AddScore.onSendScore -= OnSendScore;
	}

	void Start(){
		time = 0.00;
		UpdateUI ();
	}

	void Update(){
		time += Time.deltaTime;

		UpdateUI ();
	}

	void HandleOnUpdateHealth(int newHealth){
		health = newHealth;
		UpdateUI ();
	}

	void OnSendScore(int theScore){
		score += theScore;
		UpdateUI ();
	}

	void UpdateUI(){
		gameInfo = "Score : " + score.ToString () + "\nHealth : " + health + "\nTime : " + time.ToString ("F2");;
	}

	void OnGUI(){
		GUI.Box (boxRect, gameInfo);
	}
}
