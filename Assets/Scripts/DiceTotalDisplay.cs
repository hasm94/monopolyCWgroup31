// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-10-2018
// ***********************************************************************
// <summary>Displays the dice on screen</summary>
// ***********************************************************************
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Class DiceTotalDisplay.
/// </summary>
public class DiceTotalDisplay : MonoBehaviour
{

    /// <summary>
    /// The game state
    /// </summary>
    private Monopoly theGameState;

    /// <summary>
    /// The roll over
    /// </summary>
    int rollOver = 0;
    /// <summary>
    /// The roll over finish
    /// </summary>
    public bool rollOverFinish = true;

    // Use this for initialization
    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start()
    {
        theGameState = GameObject.FindObjectOfType<Monopoly>();

    }


    // Update is called once per frame
    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update()
    {
        if (theGameState.isDoneRolling == false)
        {
            GetComponent<Text>().text = "?";
        }
        else
        {
            GetComponent<Text>().text = "" + theGameState.diceTotal;
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
