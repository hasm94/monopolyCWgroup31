using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DiceTotalDisplay : MonoBehaviour {

	private Monopoly theGameState;

	int rollOver = 0;
	public bool rollOverFinish = true;

	// Use this for initialization
	void Start() 
	{
		theGameState = GameObject.FindObjectOfType<Monopoly>();	
			
	}


	// Update is called once per frame
	void Update() 
	{
		if (theGameState.isDoneRolling == false) {
			GetComponent<Text> ().text = "?";
		} else {
			GetComponent<Text> ().text = "" + theGameState.diceTotal;
		}
		
	}
}


//Debug.Log (rollOver);
//if (rollOverFinish == true) {
//	rollOver = 0;
//}
//
//if (diceRoller.isRolling == true) {
//	GetComponent<Text> ().text = "= ?";
//} else {
//	//Debug.Log (diceRollerOne.die + " and " + diceRollerTwo.die);
//	if (diceRoller.dice[0] == diceRoller.dice[1]) {
//		rollOverFinish = false;
//		rollOver++;
//
//		if (rollOver == 1) {
//			GetComponent<Text> ().text = "= Double, Roll again";
//		} else if (rollOver == 2) {
//			GetComponent<Text> ().text = "= Triple, Go to Jail!";
//		} 
//	} else {
//		GetComponent<Text> ().text = "= " + (diceRoller.dice[0] + diceRoller.dice[1]);
//		rollOverFinish = true;
//	}
//}
