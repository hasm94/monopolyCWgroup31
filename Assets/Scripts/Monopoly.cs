using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monopoly : MonoBehaviour {

	public enum TurnPhase {NEW_TURN,
		WAITING, DONE_CLICKING, 
		WAITING_FOR_ROLL, DONE_ROLLING, 
		WAITING_FOR_ANIMATION, ANIMATING, DONE_ANIMATING
	};
	public TurnPhase currentPhase;

	public bool isDoneClicking = false;
	public bool isDoneRolling = false;
	public bool isDoneAnimating = false;

	public bool newTurnPossible = true;

	public int noPlayers;

	public Player[] players;
	public Tile[] tiles;
    public Street[] streets;
	public int currentPlayerId;

	public int diceTotal;

	// Use this for initialization
	void Start () {
		//TODO: Intialise players from menu
		noPlayers = PlayerPrefs.GetInt("noPlayers");
		for (int i = 5; i >= noPlayers; i--) {
			Debug.Log(i);
			players[i].destroyToken();
		}

		currentPhase = Monopoly.TurnPhase.NEW_TURN;
	}

	public void NewTurn()
	{

//		
		if (newTurnPossible) {
			newTurnPossible = false;
		} else {
			Debug.Log ("Wait till turn is over");
			return;
		}
//			currentPhase = Monopoly.TurnPhase.WAITING;

			isDoneClicking = false;
			isDoneRolling = false;
			isDoneAnimating = false;

			//TODO: advance player via player id
			
			players [currentPlayerId].MakeMove ();

			/* if (players[currentPlayerId].diceRoller.isRolledOver) {
			    Debug.Log ("isDoneClicking should be false = " + isDoneClicking);
			    Debug.Log ("isDoneRolling should be false = " + isDoneRolling);
			    Debug.Log ("isDoneAnimating should be false = " + isDoneAnimating);
				return;
			}
            */

			players [currentPlayerId].TileDescription ();

			currentPlayerId = (currentPlayerId + 1) % noPlayers;
//		}

	}


	public void possibleActions()
	{
		Tile cTile = players [currentPlayerId].getCurrentTile ();

		if (cTile.isPurchasable()) {
            Purchasable pTile = (Purchasable)cTile;
			Debug.Log ("You have landed on a purchasable tile.");
			if (pTile.hasOwner ()) {
				
				if (pTile.getOwner () == players [currentPlayerId]) {
					Debug.Log ("You landed on your own tile. Do nothing.");
					return;
				} else {
					Debug.Log ("You have landed on a tile that is owned by another player.");

					if (pTile.isMortgaged()) {
						//nothing happens
						Debug.Log ("This tile is mortgaged. Do nothing.");
						return;

					} else {
						Debug.Log ("pay player" + pTile.getOwner() + " a rent of " + pTile);
						pTile.payRent (players [currentPlayerId]);
					}
				}


			
			} else {
				
				//TODO: Popup for actions: buy property, or send to auction.


			}
		} else {

			NonPurchasable upTile = (NonPurchasable) cTile;
			Debug.Log ("You have landed on " + cTile.name + ". Complete given action");
			upTile.completeAction();


		}

	}




	// Update is called once per frame
	void Update () {

		if (isDoneClicking && isDoneRolling && isDoneAnimating)
		{
			//Debug.Log("Turn is complete!");
			newTurnPossible = true;
			currentPhase = Monopoly.TurnPhase.NEW_TURN;
		}
	}
	
	public int getStreetId(Colour colour){
		for(int i = 0; i < streets.Length; i++){
			if(streets[i].streetColour == colour){
				return i;
			}
		}
		return -1;
	}
}
