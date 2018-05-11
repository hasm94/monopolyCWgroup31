// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-10-2018
// ***********************************************************************
// <summary>Represents the dice for each player</summary>
// ***********************************************************************
using UnityEngine.UI;
using UnityEngine;


/// <summary>
/// Class DiceRoller.
/// </summary>
public class DiceRoller : MonoBehaviour
{

    /// <summary>
    /// The game state
    /// </summary>
    private Monopoly theGameState;

    /// <summary>
    /// The numbers on the dice
    /// </summary>
    public int[] dice;
    /// <summary>
    /// The dice image
    /// </summary>
    public Sprite[] diceImage;


    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start()
    {
        theGameState = GameObject.FindObjectOfType<Monopoly>();

        dice = new int[2];
    }

    // Update is called once per frame
    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update()
    {
    }

    /// <summary>
    /// Rolls the dice. By generating two random numbers between 1-6. And checks for double roll. Updates graphic.
    /// </summary>
    public void RollTheDice()
    {
        if (theGameState.isDoneClicking)
        {
            return;
        }

        theGameState.diceTotal = 0;

        for (int i = 0; i < dice.Length; i++)
        {
            dice[i] = Random.Range(1, 7);
            theGameState.diceTotal += dice[i];
            // Update visuals to show the dice roll

            if (dice[i] == 1)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = diceImage[0];
            }
            else if (dice[i] == 2)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = diceImage[1];
            }
            else if (dice[i] == 3)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = diceImage[2];
            }
            else if (dice[i] == 4)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = diceImage[3];
            }
            else if (dice[i] == 5)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = diceImage[4];
            }
            else if (dice[i] == 6)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = diceImage[5];
            }
        }
        Debug.Log("Rolled: " + dice[0] + " and " + dice[1]);
        theGameState.isDoneRolling = true;
        //theGameState.currentPhase = Monopoly.TurnPhase.DONE_ROLLING;
    }

    /// <summary>
    /// Gets the latest roll.
    /// </summary>
    /// <returns>System.Int32[].</returns>
    public int[] GetRoll()
    {
        return dice;
    }


}
