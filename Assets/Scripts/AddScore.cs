using UnityEngine;
using System.Collections;

public class AddScore : MonoBehaviour {

	public delegate void SendScore(int score);
	public static event SendScore onSendScore;

	public int score = 10;

	public void DoSendScore(){

		if (onSendScore != null)
						onSendScore (score);
	}
}
