using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public static class DiceRoller : MonoBehaviour {

	private Monopoly theGameState;

	public int[] dice;
	public Sprite[] diceImage;


	// Use this for initialization
	void Start ()
	{
		theGameState = GameObject.FindObjectOfType<Monopoly>();

		dice = new int[2];
	}

	// Update is called once per frame
	void Update ()
	{
	}

	// Generate two random numbers.
	// Check whether double roll is due.
	// Print the graphic.
	public void RollTheDice()
	{
		if (theGameState.isDoneClicking) {
			return;
		}

		theGameState.diceTotal = 0;

		for (int i = 0; i < dice.Length; i++) {
			dice [i] = Random.Range (1, 7);
			theGameState.diceTotal += dice [i];
			// Update visuals to show the dice roll

			if (dice[i] == 1) {
				this.transform.GetChild (i).GetComponent<Image> ().sprite = diceImage [0];
			} else if (dice[i] == 2) {
				this.transform.GetChild (i).GetComponent<Image> ().sprite = diceImage [1];
			} else if (dice[i] == 3) {
				this.transform.GetChild (i).GetComponent<Image> ().sprite = diceImage [2];
			} else if (dice[i] == 4) {
				this.transform.GetChild (i).GetComponent<Image> ().sprite = diceImage [3];
			} else if (dice[i] == 5) {
				this.transform.GetChild (i).GetComponent<Image> ().sprite = diceImage [4];
			} else if (dice[i] == 6) {
				this.transform.GetChild (i).GetComponent<Image> ().sprite = diceImage [5];
			}
		}
		Debug.Log ("Rolled: " + dice[0] + " and " + dice[1]);
		theGameState.isDoneRolling = true;
		//theGameState.currentPhase = Monopoly.TurnPhase.DONE_ROLLING;
	}


}
